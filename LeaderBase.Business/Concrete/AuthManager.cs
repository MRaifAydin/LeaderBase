using LeaderBase.Business.Abstract;
using LeaderBase.Core.Entities.PostgreSQL.Authentication;
using LeaderBase.Core.Utilities.Constants;
using LeaderBase.Core.Utilities.Results;
using LeaderBase.Core.Utilities.Security.Hashing;
using LeaderBase.Core.Utilities.Security.JWT;
using LeaderBase.DTO.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private IUserOperationClaimService _userOperationClaimService;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimService userOperationClaimService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userOperationClaimService = userOperationClaimService;
        }

        public IDataResult<User> Login(UserLoginDto userLoginDto)
        {
            var checkUser = _userService.GetByEmail(userLoginDto.Email);
            if (checkUser == null)
            {
                return new ErrorDataResult<User>(Message.UserNotFound);
            }
            else if (!HashingHelper.VerifyPasswordHash(password: userLoginDto.Password, passwordSalt: checkUser.PasswordSalt, passwordHash: checkUser.PasswordHash))
            {
                return new ErrorDataResult<User>(Message.PasswordError);
            }
            else
            {
                return new SuccessDataResult<User>(data: checkUser, message: Message.LoginSuccessful);
            }

        }

        public IDataResult<User> Register(UserRegisterDto userRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, passwordSalt: out passwordSalt, passwordHash: out passwordHash);

            var user = new User()
            {
                Email = userRegisterDto.Email,
                Name = userRegisterDto.Name,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                Status = true
            };

            _userService.InsertOneAsync(user);
            return new SuccessDataResult<User>(data: user, message: Message.RegisterSuccessful);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userOperationClaimService.GetById(user.Id);
            var accessToken = _tokenHelper.CreateToken(user: user, operationClaims: claims.OperationClaim);
            return new SuccessDataResult<AccessToken>(data: accessToken, message: Message.AccessTokenGranted);
        }

        public IResult UserExist(string email)
        {
            if (_userService.GetByEmail(email) != null)
            {
                return new ErrorResult();
            }
            else return new SuccessResult();
        }
    }
}

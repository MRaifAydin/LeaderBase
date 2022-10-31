using LeaderBase.Core.Entities.PostgreSQL.Authentication;
using LeaderBase.Core.Utilities.Results;
using LeaderBase.Core.Utilities.Security.JWT;
using LeaderBase.DTO.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Business.Abstract
{
    public interface IAuthService
    {
        public IDataResult<User> Register(UserRegisterDto userRegisterDto, string password);

        public IDataResult<User> Login(UserLoginDto userLoginDto);

        public IResult UserExist(string email);

        public IDataResult<AccessToken> CreateAccessToken(User user);
    }
}

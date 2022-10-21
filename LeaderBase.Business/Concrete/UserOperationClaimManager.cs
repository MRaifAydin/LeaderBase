using LeaderBase.Business.Abstract;
using LeaderBase.Core.Entities.PostgreSQL.Authentication;
using LeaderBase.DTO.Authentication;
using LeaderBase.Repository.PostgreSQL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        IUserOperationClaimRepository _userOperationClaimRepository;
        IUserRepository _userRepository;
        IOperationClaimRepository _operationClaimRepository;

        public UserOperationClaimManager(IUserOperationClaimRepository userOperationClaimRepository, IUserRepository userRepository, IOperationClaimRepository operationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _userRepository = userRepository;
            _operationClaimRepository = operationClaimRepository;
        }

        UserOperationClaimDto FillEntity(UserOperationClaim entity)
        {
            UserOperationClaimDto response = default;
            response.User = _userRepository.Get(entity.UserId);
            response.OperationClaim = _operationClaimRepository.Get(entity.OperationClaimId);
            return response;
        }

        public List<UserOperationClaimDto> GetAll()
        {
            var entities = _userOperationClaimRepository.GetAll().ToList();
            var response = entities.Select(x => Get(x.Id)).ToList();
            return response;
        }

        public UserOperationClaimDto Get(int id)
        {
            UserOperationClaim entity = _userOperationClaimRepository.Get(id);
            return FillEntity(entity);
        }

        public void InsertOneAsync(UserOperationClaim entity)
        {
            _userOperationClaimRepository.InsertOneAsync(entity);
        }

        public void UpdateAsync(UserOperationClaim entity)
        {
            _userOperationClaimRepository.UpdateAsync(entity);
        }
        public void DeleteAsync(int id)
        {
            _userOperationClaimRepository.DeleteAsync(id);
        }

    }
}

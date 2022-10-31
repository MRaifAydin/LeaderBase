using LeaderBase.Core.Entities.PostgreSQL.Authentication;
using LeaderBase.DTO.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Business.Abstract
{
    public interface IUserOperationClaimService
    {
        public List<UserOperationClaimDto> GetAll();
        public UserOperationClaimDto GetById(int id);
        public void InsertOneAsync(UserOperationClaim entity);
        public void UpdateAsync(UserOperationClaim entity);
        public void DeleteAsync(int id);
    }
}

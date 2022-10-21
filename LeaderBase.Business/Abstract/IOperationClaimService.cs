using LeaderBase.Core.Entities.PostgreSQL.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Business.Abstract
{
    public interface IOperationClaimService
    {
        public List<OperationClaim> GetAll();
        public OperationClaim Get(int id);
        public void InsertOneAsync(OperationClaim entity);
        public void UpdateAsync(OperationClaim entity);
        public void DeleteAsync(int id);
    }
}

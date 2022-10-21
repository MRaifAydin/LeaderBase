using LeaderBase.Business.Abstract;
using LeaderBase.Core.Entities.PostgreSQL.Authentication;
using LeaderBase.Repository.PostgreSQL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        IOperationClaimRepository _operationClaimRepository;

        public OperationClaimManager(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public List<OperationClaim> GetAll()
        {
            return _operationClaimRepository.GetAll().ToList();
        }
        public OperationClaim Get(int id)
        {
            return _operationClaimRepository.Get(id);
        }

        public void InsertOneAsync(OperationClaim entity)
        {
            _operationClaimRepository.InsertOneAsync(entity);
        }

        public void UpdateAsync(OperationClaim entity)
        {
            _operationClaimRepository.UpdateAsync(entity);
        }

        public void DeleteAsync(int id)
        {
            _operationClaimRepository.DeleteAsync(id);
        }
    }
}

using LeaderBase.Core.Entities.PostgreSQL.Authentication;
using LeaderBase.Repository.PostgreSQL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Repository.PostgreSQL.Abstract
{
    public interface IOperationClaimRepository : IBaseRepository<OperationClaim>
    {
    }
}
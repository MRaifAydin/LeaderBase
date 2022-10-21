using LeaderBase.Core.Entities.PostgreSQL.Authentication;
using LeaderBase.DataAccess;
using LeaderBase.Repository.PostgreSQL.Abstract;
using LeaderBase.Repository.PostgreSQL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Repository.PostgreSQL.Concrete
{
    public class OperationClaimRepository : BaseRepository<OperationClaim>, IOperationClaimRepository
    {
        public OperationClaimRepository(AppDbContext context) : base(context)
        {
        }
    }
}

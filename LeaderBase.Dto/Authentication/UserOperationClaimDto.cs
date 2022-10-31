using LeaderBase.Core.Entities.PostgreSQL.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.DTO.Authentication
{
    public class UserOperationClaimDto
    {
        public User User { get; set; }
        public List<OperationClaim> OperationClaim { get; set; }
    }
}

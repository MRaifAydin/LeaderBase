using LeaderBase.Core.PostgreSQL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Core.Entities.PostgreSQL.Authentication
{
    public class OperationClaim : BaseEntity
    {
        public string Name { get; set; }
    }
}

using LeaderBase.Core.PostgreSQL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Core.Entities.PostgreSQL.Authentication
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}

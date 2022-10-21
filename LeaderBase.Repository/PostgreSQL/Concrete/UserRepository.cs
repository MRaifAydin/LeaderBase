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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}

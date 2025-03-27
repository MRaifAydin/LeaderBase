using LeaderBase.Core.Auth.Entities;
using LeaderBase.DataAccess;
using LeaderBase.Repository.Auth.Abstract;
using LeaderBase.Repository.Auth.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Repository.Auth.Concrete
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(UserDbContext context) : base(context)
        {
        }
    }
}

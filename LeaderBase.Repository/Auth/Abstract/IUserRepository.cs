using LeaderBase.Core.Auth.Entities;
using LeaderBase.Repository.Auth.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Repository.Auth.Abstract
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}

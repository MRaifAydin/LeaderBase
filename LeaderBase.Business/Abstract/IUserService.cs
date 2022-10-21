using LeaderBase.Core.Entities.PostgreSQL.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Business.Abstract
{
    public interface IUserService
    {
        public IQueryable<User> GetAll();
        public User Get(int id);
        public void InsertOneAsync(User entity);
        public void UpdateAsync(User entity);
        public void DeleteAsync(int id);
    }
}

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
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IQueryable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User Get(int id)
        {
            return _userRepository.Get(id);
        }

        public void InsertOneAsync(User entity)
        {
            _userRepository.InsertOneAsync(entity);
        }

        public void UpdateAsync(User entity)
        {
            _userRepository.UpdateAsync(entity);
        }

        public void DeleteAsync(int id)
        {
            _userRepository.DeleteAsync(id);
        }
    }
}

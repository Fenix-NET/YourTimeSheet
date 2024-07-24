using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourTimeSheet.Core.Contracts;
using YourTimeSheet.Core.Entities.IdentityModels;

namespace YourTimeSheet.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(Guid id)
        {
            return _userRepository.GetUserById(id);
        }

        public User GetUserByUsername(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }

        public void RegisterUser(User user)
        {
            _userRepository.AddUser(user);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourTimeSheet.Core.Contracts;
using YourTimeSheet.Core.Entities.IdentityModels;

namespace YourTimeSheet.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        public User GetUserById(Guid id)
        {
            //return _dbContext.FirstOrDefault(u => u.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            //return _dbContext.FirstOrDefault(u => u.Username == username);
        }

        public void AddUser(User user)
        {
            //_dbContext.Add(user);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourTimeSheet.Core.Entities.IdentityModels;

namespace YourTimeSheet.Core.Contracts
{
    public interface IUserRepository
    {
        User GetUserById(Guid id);
        User GetUserByUsername(string username);
        void AddUser(User user);

    }
}

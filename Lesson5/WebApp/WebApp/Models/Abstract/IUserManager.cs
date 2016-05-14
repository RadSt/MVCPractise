using System.Collections.Generic;
using WebApp.Models.Enteties;

namespace WebApp.Models.Abstract
{
    public interface IUserManager
    {
        IEnumerable<User> Users { get; }
        IEnumerable<Role> Roles { get; } 
        bool Save(User user);
        bool RemoveUser(int userId);
    }
}
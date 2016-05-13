using System.Collections.Generic;
using WebApp.Models.Enteties;

namespace WebApp.Models.Abstract
{
    public interface IUserManager
    {
        IEnumerable<User> Users { get; }
        bool Save(User role);
        bool RemoveUser(int userId);
    }
}
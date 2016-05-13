using System.Collections.Generic;
using WebApp.Models.Enteties;

namespace WebApp.Models.Abstract
{
    public interface IRolesManager
    {
        IEnumerable<Role> Roles { get; }
        bool Save(Role role);
        bool RemoveRole(int roleId);
    }
}
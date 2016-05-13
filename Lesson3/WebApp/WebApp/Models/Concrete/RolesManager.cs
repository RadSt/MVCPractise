using System;
using System.Collections.Generic;
using WebApp.Models.Abstract;
using WebApp.Models.Enteties;

namespace WebApp.Models.Concrete
{
    public class RolesManager : IRolesManager
    {
        private readonly WebAppDbContext _context = new WebAppDbContext();

        public IEnumerable<Role> Roles
        {
            get { return _context.Roles; }
        }

        public bool Save(Role role)
        {
            if (role == null) return false;
            if (role.RoleId == 0)
            {
                _context.Roles.Add(role);
            }
            else
            {
                Role dbRole = _context.Roles.Find(role.RoleId);
                if (dbRole != null)
                {
                    dbRole.Name = role.Name;
                    dbRole.Code = role.Code;
                    dbRole.Users = role.Users;
                }
            }
            _context.SaveChanges();
            return true;
        }
        public bool RemoveRole(int roleId)
        {
            var role = _context.Roles.Find(roleId);
            if (role == null) return false;
            _context.Roles.Remove(role);
            return true;
        }
    }
}
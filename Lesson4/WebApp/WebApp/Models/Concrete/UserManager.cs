using System.Collections.Generic;
using WebApp.Models.Abstract;
using WebApp.Models.Enteties;

namespace WebApp.Models.Concrete
{
    public class UserManager : IUserManager
    {
        private readonly WebAppDbContext _context = new WebAppDbContext();

        public IEnumerable<User> Users
        {
            get { return _context.Users; }
        }

        public IEnumerable<Role> Roles
        {
            get { return _context.Roles; }
        } 

        public bool Save(User user)
        {
            if (user == null) return false;

            var dbUser = _context.Users.Find(user.UserName);
            if (dbUser != null)
            {
                dbUser.UserName = user.UserName;
                dbUser.Password = user.Password;
                dbUser.Email = user.Email;
                dbUser.Roles = user.Roles;
            }
            else
            {
                _context.Users.Add(user);
            }
            _context.SaveChanges();
            return true;
        }

        public bool RemoveUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null) return false;
            _context.Users.Remove(user);
            return true;
        }
    }
}
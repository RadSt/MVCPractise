using System;
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

        public bool Save(User user)
        {
            if (user == null) return false;
            if (user.UserId == 0)
            {
                _context.Users.Add(user);
            }
            else
            {
                User dbUser = _context.Users.Find(user.UserId);
                if (dbUser != null)
                {
                    dbUser.Name = user.Name;
                    dbUser.Password = user.Password;
                    dbUser.Email = user.Email;
                    dbUser.Roles = user.Roles;
                }
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
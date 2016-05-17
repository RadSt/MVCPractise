using System;
using System.Linq;
using System.Web.Security;
using WebApp.Models.Abstract;
using WebApp.Models.Enteties;

namespace WebApp.Models.Concrete
{
    public class CustomRoleProvider : RoleProvider, ICustomRoleProvider
    {
        public override string[] GetRolesForUser(string username)
        {
            string[] role = {};
            using (WebAppDbContext dbContext = new WebAppDbContext())
            {
                try
                {
                    User user = dbContext.Users.FirstOrDefault(us => us.UserName == username);
                    if (user != null)
                    {
                        Role userRole = dbContext.Roles.Find(user.RoleId);

                        if (userRole != null)
                        {
                            role = new string[] {userRole.Name};
                        }
                    }
                }
                catch (Exception)
                {
                    role = new string[] {};
                }
            }
            return role;
        }
        public override void CreateRole(string roleName)
        {
            Role newRole = new Role() {Name = roleName};
            WebAppDbContext dbContext = new WebAppDbContext();
            dbContext.Roles.Add(newRole);
            dbContext.SaveChanges();
        }
        public override bool IsUserInRole(string userName, string roleName)
        {
            bool outputResult = false;
            using (WebAppDbContext dbContext = new WebAppDbContext())
            {
                try
                {
                    User user = dbContext.Users.FirstOrDefault(us => us.UserName == userName);
                    if (user != null)
                    {
                        Role userRole = dbContext.Roles.Find(user.RoleId);
                        if (userRole != null && userRole.Name == roleName)
                        {
                            outputResult = true;
                        }
                    }
                }
                catch (Exception)
                {
                    outputResult = false;
                }
            }
            return outputResult;
        }
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new System.NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new System.NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new System.NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}
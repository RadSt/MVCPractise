using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using WebApp.Models.Enteties;

namespace WebApp.Models.Concrete
{
    public class WebAppDbInitializer : DropCreateDatabaseIfModelChanges<WebAppDbContext>
    {
        protected override void Seed(WebAppDbContext dbContext)
        {
            // Create Admin User on DataBase Creating
            User adminUser = new User
            {
                UserName = "Admin",
                BirthdateDate = DateTime.Now,
                Email = "desan1986@gmail.com",
                Password = Crypto.HashPassword("Desan1986"),
                Role = new Role
                {
                    Name = "admin"
                }
            };

            dbContext.Users.Add(adminUser);
            dbContext.SaveChanges();

            Role userRole = new Role
            {
                Name = "user"
            };
            dbContext.Roles.Add(userRole);
            dbContext.SaveChanges();
        }
    }
}
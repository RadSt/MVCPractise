using System;
using System.Data.Entity.Migrations;
using System.Web.Helpers;
using WebApp.Models.Concrete;
using WebApp.Models.Enteties;

namespace WebApp.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<WebAppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebAppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            context.Users.AddOrUpdate(
                new User
                {
                    UserName = "Admin",
                    BirthdateDate = DateTime.Now,
                    Email = "desan1986@gmail.com",
                    Password = Crypto.HashPassword("Desan1986"),
                    Role = new Role
                    {
                        RoleId = 1,
                        Name = "admin"
                    }
                }
                );

            context.Roles.AddOrUpdate(
                new Role
                {
                    RoleId = 2,
                    Name = "user"
                }
                );
        }
    }
}
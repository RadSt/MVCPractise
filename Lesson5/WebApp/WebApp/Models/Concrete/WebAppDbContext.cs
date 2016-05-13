using System.Data.Entity;
using WebApp.Models.Enteties;

namespace WebApp.Models.Concrete
{
    public class WebAppDbContext : DbContext
    {
        /// <summary>
        /// Управление БД
        /// </summary>
        public WebAppDbContext()
        {
            // Указывает что Нужно пересоздать БД при изменении моделей
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<WebAppDbContext>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Set the links many to many with fluent api Add New Table name
            modelBuilder.Entity<User>()
                .HasMany(p => p.Roles)
                .WithMany(c => c.Users)
                .Map(m =>
                {
                    m.ToTable("UserRoles");
                });
        }
    }
}
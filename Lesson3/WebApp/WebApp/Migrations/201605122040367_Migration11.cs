namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration11 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserRole", newName: "UserRoles");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.UserRoles", newName: "UserRole");
        }
    }
}

namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 150),
                        Password = c.String(maxLength: 50),
                        AddedDate = c.DateTime(nullable: false),
                        ActivatedDate = c.DateTime(nullable: false),
                        ActivatedLink = c.String(maxLength: 50),
                        LastVisitDate = c.DateTime(nullable: false),
                        AvatarPath = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        Role_RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.Role_RoleId })
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_RoleId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.Role_RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRole", "User_UserId", "dbo.Users");
            DropIndex("dbo.UserRole", new[] { "Role_RoleId" });
            DropIndex("dbo.UserRole", new[] { "User_UserId" });
            DropTable("dbo.UserRole");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
        }
    }
}

namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Name", c => c.String(maxLength: 150));
            DropColumn("dbo.Users", "AddedDate");
            DropColumn("dbo.Users", "ActivatedDate");
            DropColumn("dbo.Users", "ActivatedLink");
            DropColumn("dbo.Users", "LastVisitDate");
            DropColumn("dbo.Users", "AvatarPath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "AvatarPath", c => c.String(maxLength: 150));
            AddColumn("dbo.Users", "LastVisitDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "ActivatedLink", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "ActivatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "AddedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Users", "Name");
        }
    }
}

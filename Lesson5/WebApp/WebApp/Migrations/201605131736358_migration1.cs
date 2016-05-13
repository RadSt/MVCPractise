namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ConfirmPassword", c => c.String());
            AddColumn("dbo.Users", "Captcha", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Captcha");
            DropColumn("dbo.Users", "ConfirmPassword");
        }
    }
}

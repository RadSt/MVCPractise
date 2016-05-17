namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "BirthdateDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Users", "BirthdayDate");
            DropColumn("dbo.Users", "Captcha");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Captcha", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "BirthdayDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Users", "BirthdateDate");
        }
    }
}

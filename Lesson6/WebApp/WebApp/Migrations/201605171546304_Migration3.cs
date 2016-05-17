namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Roles", "Code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "Code", c => c.String(maxLength: 50));
        }
    }
}

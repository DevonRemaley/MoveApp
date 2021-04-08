namespace MoveApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class midnight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "FirstName", c => c.String());
            AddColumn("dbo.ApplicationUser", "LastName", c => c.String());
            DropColumn("dbo.ApplicationUser", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "FullName", c => c.String());
            DropColumn("dbo.ApplicationUser", "LastName");
            DropColumn("dbo.ApplicationUser", "FirstName");
        }
    }
}

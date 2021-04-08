namespace MoveApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SavedRide", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.SavedRide", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SavedRide", "Date", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.SavedRide", "CreatedUtc");
        }
    }
}

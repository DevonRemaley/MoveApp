namespace MoveApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ok : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SavedRide", "Name", c => c.String(nullable: false));
            AddColumn("dbo.SavedRide", "Description", c => c.String());
            AddColumn("dbo.SavedRide", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.RideStats", "CreatedUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RideStats", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.SavedRide", "CreatedUtc");
            DropColumn("dbo.SavedRide", "Description");
            DropColumn("dbo.SavedRide", "Name");
        }
    }
}

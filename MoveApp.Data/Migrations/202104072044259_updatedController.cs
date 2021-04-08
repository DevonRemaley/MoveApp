namespace MoveApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedController : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SavedRide", "Description", c => c.String());
            DropColumn("dbo.RideStats", "Calories");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RideStats", "Calories", c => c.Int(nullable: false));
            DropColumn("dbo.SavedRide", "Description");
        }
    }
}

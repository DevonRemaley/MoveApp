namespace MoveApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class distanceToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RideStats", "Distance", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RideStats", "Distance", c => c.Int(nullable: false));
        }
    }
}

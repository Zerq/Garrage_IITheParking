namespace GarageII_TheParking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Parkdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "ExpectedParkOutDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehicles", "ParkOutDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "ParkOutDate");
            DropColumn("dbo.Vehicles", "ExpectedParkOutDate");
        }
    }
}

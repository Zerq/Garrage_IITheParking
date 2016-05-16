namespace GarageII_TheParking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YoMommaTo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "ParkedDate", c => c.DateTime());
            AlterColumn("dbo.Vehicles", "ExpectedParkOutDate", c => c.DateTime());
            AlterColumn("dbo.Vehicles", "ParkOutDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "ParkOutDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Vehicles", "ExpectedParkOutDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Vehicles", "ParkedDate", c => c.DateTime(nullable: false));
        }
    }
}

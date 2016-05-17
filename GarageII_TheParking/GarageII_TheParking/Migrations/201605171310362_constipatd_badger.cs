namespace GarageII_TheParking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class constipatd_badger : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehicles", "ParkOutDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "ParkOutDate", c => c.DateTime());
        }
    }
}

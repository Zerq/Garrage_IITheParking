namespace GarageII_TheParking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Garages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Color = c.Int(nullable: false),
                        RegistrationNumber = c.String(),
                        Type = c.Int(nullable: false),
                        WheelCount = c.Int(nullable: false),
                        Brand = c.String(),
                        ParkedDate = c.DateTime(nullable: false),
                        ExpectedParkOutDate = c.DateTime(nullable: false),
                        ParkOutDate = c.DateTime(nullable: false),
                        Garage_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Garages", t => t.Garage_Id)
                .Index(t => t.Garage_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "Garage_Id", "dbo.Garages");
            DropIndex("dbo.Vehicles", new[] { "Garage_Id" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.Garages");
        }
    }
}

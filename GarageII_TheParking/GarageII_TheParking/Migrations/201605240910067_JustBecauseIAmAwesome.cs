namespace GarageII_TheParking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JustBecauseIAmAwesome : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Garages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CostPerHour = c.Int(nullable: false),
                        CostPerDay = c.Int(),
                        CostPerWeek = c.Int(),
                        CostPerMonth = c.Int(),
                        MaxDuration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        LastName = c.String(),
                        PersonIdNumber = c.String(),
                        PhoneNr = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Color = c.Int(nullable: false),
                        RegistrationNumber = c.String(),
                        WheelCount = c.Int(nullable: false),
                        Brand = c.String(),
                        ParkedDate = c.DateTime(),
                        ExpectedParkOutDate = c.DateTime(),
                        GarageId = c.Guid(nullable: false),
                        PersonWhoParkedVechicle_Id = c.Guid(nullable: false),
                        Type_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.PersonWhoParkedVechicle_Id, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTypes", t => t.Type_Id, cascadeDelete: true)
                .Index(t => t.PersonWhoParkedVechicle_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "Type_Id", "dbo.VehicleTypes");
            DropForeignKey("dbo.Vehicles", "PersonWhoParkedVechicle_Id", "dbo.Members");
            DropIndex("dbo.Vehicles", new[] { "Type_Id" });
            DropIndex("dbo.Vehicles", new[] { "PersonWhoParkedVechicle_Id" });
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Members");
            DropTable("dbo.Garages");
        }
    }
}

namespace GarageII_TheParking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LooserGarageConnectionII : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehicles", "Garage_Id", "dbo.Garages");
            DropIndex("dbo.Vehicles", new[] { "Garage_Id" });
            AddColumn("dbo.Vehicles", "GarageId", c => c.Guid(nullable: false));
            DropColumn("dbo.Vehicles", "Garage_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "Garage_Id", c => c.Guid());
            DropColumn("dbo.Vehicles", "GarageId");
            CreateIndex("dbo.Vehicles", "Garage_Id");
            AddForeignKey("dbo.Vehicles", "Garage_Id", "dbo.Garages", "Id");
        }
    }
}

namespace GarageII_TheParking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YouMomma : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Garages", "CostPerHour", c => c.Int(nullable: false));
            AddColumn("dbo.Garages", "CostPerDay", c => c.Int());
            AddColumn("dbo.Garages", "CostPerWeek", c => c.Int());
            AddColumn("dbo.Garages", "CostPerMonth", c => c.Int());
            AddColumn("dbo.Garages", "MaxDuration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Garages", "MaxDuration");
            DropColumn("dbo.Garages", "CostPerMonth");
            DropColumn("dbo.Garages", "CostPerWeek");
            DropColumn("dbo.Garages", "CostPerDay");
            DropColumn("dbo.Garages", "CostPerHour");
        }
    }
}

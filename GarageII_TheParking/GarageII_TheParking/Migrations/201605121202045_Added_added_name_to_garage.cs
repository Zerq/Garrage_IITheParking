namespace GarageII_TheParking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_added_name_to_garage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Garages", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Garages", "Name");
        }
    }
}

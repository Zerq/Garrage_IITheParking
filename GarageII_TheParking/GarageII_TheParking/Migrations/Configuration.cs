namespace GarageII_TheParking.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GarageII_TheParking.DataAccessLayer.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GarageII_TheParking.DataAccessLayer.Context context)
        {
            context.Garage.AddOrUpdate(n => n.Id, new Models.Garage() { Id = Guid.Empty, Name = "Garrage II: The parking" });

         
        }
    }
}

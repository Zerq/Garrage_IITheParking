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
            context.Garage.AddOrUpdate(n => n.Id, new Models.Garage() { Id = Guid.Empty, Name = "Garrage SIII: Return of the parkinator!", CostPerDay = 900, CostPerMonth = 15000, CostPerWeek = 5000, CostPerHour = 60, MaxDuration = 9000000 });

            var car = new Models.VehicleType() { Id = new Guid("b9534ea5-f575-4f66-b986-7a4888cc146e"), Name = "Car" };
            var Buss = new Models.VehicleType() { Id = new Guid("4f7367a8-249b-4a8f-98e7-cd0ef24b9b41"), Name = "Buss" };
            var BearCavalry = new Models.VehicleType() { Id = new Guid("a70cfd69-5fa7-4d94-be2e-c1c0a7dc975c"), Name = "BearCavalry" };
            var Airoplane = new Models.VehicleType() { Id = new Guid("5f424c22-06f0-4a62-a0a2-801d57b6391b"), Name = "Airoplane" };
            var Pogostick = new Models.VehicleType() { Id = new Guid("e4bb7460-b6a2-4ec9-a547-8e6d71a77171"), Name = "Pogostick" };
            var MotorCycle = new Models.VehicleType() { Id = new Guid("97b6eda3-673b-4f4b-9718-73003d49a0ce"), Name = "MotorCycle" };
            var Boat = new Models.VehicleType() { Id = new Guid("b3b72b3f-c89b-41a8-bb06-933cc59243c9"), Name = "Boat" };
            var NinjaCatRidingADinosaureWithGrabyClaws = new Models.VehicleType() { Id = new Guid("2b5aa001-fa0e-41a1-b083-c7ad3f013e34"), Name = "NinjaCatRidingADinosaureWithGrabyClaws" };
            //https://cdn0.vox-cdn.com/thumbor/dUhFuohIxvh-F4v3EKsjY3XSWIU=/cdn0.vox-cdn.com/uploads/chorus_asset/file/3893454/win10_skype_320x320.0.gif

            context.VehicleTypes.AddOrUpdate(n => n.Id, car, Buss, BearCavalry, Airoplane, Pogostick, MotorCycle, Boat, NinjaCatRidingADinosaureWithGrabyClaws);
         
        }
    }
}

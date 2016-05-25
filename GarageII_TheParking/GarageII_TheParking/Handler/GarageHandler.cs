using GarageII_TheParking.DataAccessLayer;
using GarageII_TheParking.Models;
using GarageII_TheParking.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GarageII_TheParking.Handler {

    public class GarageHandler : AbstractGarageHandler  {


        internal object Collect(Models.ViewModels.CollectViewModel model) {
    

            Vehicle vehicle = db.Vehicle.SingleOrDefault( s => s.Id == model.VehicleId);
            Member collector = db.Members.SingleOrDefault(m => m.Id == model.CollectorId);
            //null check vehicle later!
            if (vehicle.PersonWhoParkedVechicle == collector) {
                if (vehicle != null) {
                    db.Vehicle.Remove(vehicle);
                    db.SaveChanges();
                }

                var kvitto = new Receipt();

                kvitto.CostPerHour = this.Garage.CostPerHour;
                kvitto.StartTime = vehicle.ParkedDate.Value;
                kvitto.TimeWhenPaidParkingTimeExpires = vehicle.ExpectedParkOutDate.Value;
                kvitto.TimeVehicleCollected = DateTime.Now;
                kvitto.Name = collector.Name;
                kvitto.LastName = collector.LastName;

                TimeSpan amountTimeParked = kvitto.TimeWhenPaidParkingTimeExpires.Subtract(kvitto.StartTime);
                kvitto.TotalCost = Convert.ToInt32(kvitto.CostPerHour * amountTimeParked.TotalHours);

                if (DateTime.Now >= vehicle.ExpectedParkOutDate) {
                    kvitto.TotalCost += 500;
                }

                return kvitto;
            } else return null;
        }

        public List<VehicleType> GetAllVehicleTypes() {
            return db.VehicleTypes.ToList();
        }

        public List<Member> GetAllMembers() {
            return db.Members.ToList();
        }

        public List<Vehicle> ListVehicles(Garage garage)
        {
            db.Configuration.LazyLoadingEnabled = false;
            var x = db.Vehicle.Where(n => n.GarageId == garage.Id).ToList();
            return x;


        }

        public  Receipt Park(Vehicle vehicle, TimeSpan amountTimePaidFor)
        {


            Receipt receipt = new Receipt();

            receipt.CostPerHour = this.Garage.CostPerHour;
            receipt.StartTime = DateTime.Now;
            receipt.TimeWhenPaidParkingTimeExpires = receipt.StartTime.Add(amountTimePaidFor);
            receipt.TimeVehicleCollected = null;
            receipt.LastName = vehicle.PersonWhoParkedVechicle.LastName;
            receipt.Name = vehicle.PersonWhoParkedVechicle.Name;


            vehicle.Id = Guid.NewGuid();
            vehicle.GarageId = this.Garage.Id;

            vehicle.ParkedDate = receipt.StartTime;
            vehicle.ExpectedParkOutDate = receipt.TimeWhenPaidParkingTimeExpires;

            TimeSpan amountTimeParked = receipt.TimeWhenPaidParkingTimeExpires.Subtract(receipt.StartTime);
            receipt.TotalCost = Convert.ToInt32(receipt.CostPerHour * amountTimeParked.TotalHours);

            db.Entry(vehicle.PersonWhoParkedVechicle).State = EntityState.Modified;
            db.Vehicle.Add(vehicle);
            db.SaveChanges();
            
            return receipt;
        }

        internal void PopulateFromView(VehicleAndAmountTimeToPark viewModel) {
            viewModel.Vehicle.Type = db.VehicleTypes.FirstOrDefault(vt => vt.Id == viewModel.VehicleType);
            viewModel.Vehicle.PersonWhoParkedVechicle = db.Members.FirstOrDefault(m => m.Id == viewModel.MemberWhoParkedVehicle);
        }

   

        // få ut ett kvitto 

        public  Vehicle GetDetails(Guid? Key) {
            db.Configuration.LazyLoadingEnabled = false;
            var vehicle = db.Vehicle.Single(n => n.Id == Key);
       
            return vehicle;
        }

   
    }
}
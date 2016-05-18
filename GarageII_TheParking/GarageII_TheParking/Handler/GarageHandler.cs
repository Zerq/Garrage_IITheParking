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

        public  Receipt Collect(Guid id)
        {

            Vehicle vehicle = db.Vehicle.SingleOrDefault( s => s.Id == id);

            if (vehicle != null)
                {
                    db.Vehicle.Remove(vehicle);
                    db.SaveChanges();
                }

            var kvitto = new Receipt();

            kvitto.CostPerHour = this.Garage.CostPerHour;
            kvitto.StartTime = vehicle.ParkedDate.Value ;
            kvitto.TimeWhenPaidParkingTimeExpires = vehicle.ExpectedParkOutDate.Value   ;
            kvitto.TimeVehicleCollected = DateTime.Now ;

            TimeSpan amountTimeParked = kvitto.TimeWhenPaidParkingTimeExpires.Subtract(kvitto.StartTime);
            kvitto.TotalCost = Convert.ToInt32(kvitto.CostPerHour * amountTimeParked.TotalHours);

            if ( DateTime.Now >= vehicle.ExpectedParkOutDate)
            {
                kvitto.TotalCost += 500;
            }

            return kvitto;

        }

        public List<Vehicle> ListVehicles(Garage garage)
        {
            return db.Vehicle.Where(n => n.GarageId == garage.Id).ToList();
        }

        public  Receipt Park(Vehicle vehicle, TimeSpan amountTimePaidFor)
        {


            Receipt receipt = new Receipt();

            receipt.CostPerHour = this.Garage.CostPerHour;
            receipt.StartTime = DateTime.Now;
            receipt.TimeWhenPaidParkingTimeExpires = receipt.StartTime.Add(amountTimePaidFor);
            receipt.TimeVehicleCollected = null;



            vehicle.Id = Guid.NewGuid();
            vehicle.GarageId = this.Garage.Id;

            vehicle.ParkedDate = receipt.StartTime;
            vehicle.ExpectedParkOutDate = receipt.TimeWhenPaidParkingTimeExpires;

            TimeSpan amountTimeParked = receipt.TimeWhenPaidParkingTimeExpires.Subtract(receipt.StartTime);
            receipt.TotalCost = Convert.ToInt32(receipt.CostPerHour * amountTimeParked.TotalHours);

            db.Vehicle.Add(vehicle);
            db.SaveChanges();
            
            return receipt;
        }
        // få ut ett kvitto 

        public  Vehicle GetDetails(Guid? Key) {
            return db.Vehicle.Single(n => n.Id  == Key);
        }

   
    }
}
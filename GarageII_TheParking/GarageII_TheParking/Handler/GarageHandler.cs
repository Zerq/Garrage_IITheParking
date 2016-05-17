using GarageII_TheParking.DataAccessLayer;
using GarageII_TheParking.Models;
using GarageII_TheParking.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GarageII_TheParking.Handler {

    public class GarageHandler : AbstractGarageHandler {




        //Singleton
        private GarageHandler() { }
        private static GarageHandler instance;
        public static GarageHandler Instance {get {
                if (instance == null) {
                    instance = new GarageHandler();
                }
                return instance;
            }

        }



        public  Receipt Collect(Vehicle vehicle) {



            throw new NotImplementedException();
            //db.Entry(Garage).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();

        }     
 
        public List<Vehicle> ListVehicles(Garage garage)
        {
            return db.Vehicle.Where(n => n.GarageId == garage.Id).ToList();
        }

        public  Receipt Park(Vehicle vehicle, TimeSpan amountTimePaidFor)
        {
            vehicle.Id = Guid.NewGuid();
            vehicle.GarageId = this.Garage.Id;
            db.Vehicle.Add(vehicle);
            db.SaveChanges();

            Receipt receipt = new Receipt( );

            receipt.CostPerHour = this.Garage.CostPerHour;
            receipt.StartTime = DateTime.Now ;
            receipt.TimeWhenPaidParkingTimeExpires = receipt.StartTime.Add(amountTimePaidFor);
            receipt.TimeVehicleCollected = null ;
            
            return receipt;
        }
        // få ut ett kvitto 

        public  Vehicle GetDetails(Guid? Key) {
            return db.Vehicle.Single(n => n.Id  == Key);
        }

        public static void Close() {
            if (instance != null) {
                instance.db.Dispose();
                instance = null;
            }
        }
    }
}
using GarageII_TheParking.DataAccessLayer;
using GarageII_TheParking.Models;
using GarageII_TheParking.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// nåt som Kalle har kodat - Stay away
namespace GarageII_TheParking.Handlers {

    public abstract class GarageHandlerbase {

       protected Context db = new Context();

        private Models.Garage garage;
        public Models.Garage Garage {
           get {
                if (garage == null) {
                   garage = db.Garage.Where(n => n.Id == Guid.Empty).First();
                }
                return garage;
            }            
        }


        public abstract Vehicle GetDetails(Guid? Key);
 

        public abstract Receipt Park(Models.Vehicle vehicle, TimeSpan paidTime);

       /* vehicle.ParkedDate = DateTime.Now;
            
            garage.Vehicle.Add(vehicle);
            db.Entry(this.Garage).State == System.Data.Entity.EntityState.Modified;
            db.SaveChanges();_*/


        public  abstract Receipt Collect(Models.Vehicle vehicle);
        // remove car from garage
        // and figure out some result to return if the car was parked to long!
        // a recite or something... that or chuck some annoyed badgers at the user or something....


 


    }
}
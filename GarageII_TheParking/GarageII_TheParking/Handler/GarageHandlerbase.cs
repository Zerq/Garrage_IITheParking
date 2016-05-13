using GarageII_TheParking.DataAccessLayer;
using GarageII_TheParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageII_TheParking.Handler {

    public abstract class GarageHandlerbase {

        Context db = new Context();
        protected IEnumerable<Models.Garage> GetGarage() {
            // get our currently singular garage out of the database...
            return db.Garage.Where(n => n.Id == Guid.Empty);
        }

        public abstract void Park(Models.Vehicle vehicle);


        public abstract Receipt Collect(Models.Vehicle vehicle);
        // remove car from garage
        // and figure out some result to return if the car was parked to long!
        // a recite or something... that or chuck some annoyed badgers at the user or something....



        public abstract List<Models.Vehicle> ListParkedVehicles();


    }
}
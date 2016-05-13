using GarageII_TheParking.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageII_TheParking.Handler {

    public class GarageHandler {
        private Context db = new Context();

        private IEnumerable<Models.Garage> GetGarage() {
            // get our currently singular garage out of the database...
            return db.Garage.Where(n => n.Id == Guid.Empty);
        }
 
        public void Park(Models.Vehicle vehicle) {
            // add care to garage
        }

        public class DevinePunishment { }
        public DevinePunishment Collect(Models.Vehicle vehicle) {
            // remove car from garage
            // and figure out some better result to return if the car was parked to long!
            // a recite or something... that or chuck some annoyed badgers at the user or something....
            return null;
        }

        public List<Models.Vehicle> ListParkedVehicles() {
            return null;
        }


    }
}
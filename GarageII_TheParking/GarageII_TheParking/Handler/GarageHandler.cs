using GarageII_TheParking.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GarageII_TheParking.Models;

namespace GarageII_TheParking.Handler {

    public class GarageHandler : GarageHandlerbase {
        public override Receipt Collect(Vehicle vehicle) {
            throw new NotImplementedException();

           // this.GetGarage()
        }

        public override List<Vehicle> ListParkedVehicles() {
            throw new NotImplementedException();
        }

        public override void Park(Vehicle vehicle) {
            throw new NotImplementedException();
        }
    }
}
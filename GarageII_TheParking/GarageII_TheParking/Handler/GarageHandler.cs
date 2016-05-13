using GarageII_TheParking.DataAccessLayer;
using GarageII_TheParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageII_TheParking.Handler {

    public class GarageHandler : GarageHandlerbase {
        public override Receipt Collect(Vehicle vehicle) {
            throw new NotImplementedException();
        }

        public override List<Vehicle> ListParkedVehicles() {
            throw new NotImplementedException();
        }

        public override Receipt Park(Vehicle vehicle) {
            throw new NotImplementedException();
        }
    }
}
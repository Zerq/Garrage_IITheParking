using GarageII_TheParking.DataAccessLayer;
using GarageII_TheParking.Models;
using GarageII_TheParking.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageII_TheParking.Handler {

    public class GarageHandler : GarageHandlerbase {

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



        public override Receipt Collect(Vehicle vehicle) {

            throw new NotImplementedException();
            //db.Entry(Garage).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();

        }
 

        public override Receipt Park(Vehicle vehicle) {
            throw new NotImplementedException();
        }

        public override Vehicle GetDetails(Guid? Key) {
            throw new NotImplementedException();
        }
    }
}
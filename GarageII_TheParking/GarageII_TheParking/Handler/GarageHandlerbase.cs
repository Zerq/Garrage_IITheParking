using GarageII_TheParking.DataAccessLayer;
using GarageII_TheParking.Models;
using GarageII_TheParking.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// nåt som Kalle har kodat - Stay away
namespace GarageII_TheParking.Handler {

    public abstract class AbstractGarageHandler : IDisposable {

       protected Context db = new Context();

        private Models.Garage garage;
        public Models.Garage Garage
        {
            get
            {
                if (garage == null)
                {
               
                    garage = db.Garage.Where(n => n.Id == Guid.Empty).First();
               
                }
                return garage;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
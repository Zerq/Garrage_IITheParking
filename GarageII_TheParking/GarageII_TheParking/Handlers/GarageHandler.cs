﻿using GarageII_TheParking.DataAccessLayer;
using GarageII_TheParking.Models;
using GarageII_TheParking.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GarageII_TheParking.Handlers {

    public class GarageHandler : GarageHandlerbase {

        //Singleton
        private GarageHandler() { }
        private static GarageHandler instance;
        public static GarageHandler GetInstance() {

       
            if (instance == null) {
                    instance = new GarageHandler();
                }
                return instance;
            

        }
        
        public override Receipt Collect(Vehicle vehicle)
        {

            
            //this.Garage.Vehicle.   //uträkningen för kvittot
            


            throw new NotImplementedException();
            //db.Entry(Garage).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();

        }
      

        public override Receipt Park(Vehicle vehicle, TimeSpan paidTime)
        {
            this.Garage.Vehicle.Add(vehicle);
            db.Entry(this.Garage).State = EntityState.Modified;
            db.SaveChanges();

            return null;
        }
        // få ut ett kvitto 

        public override Vehicle GetDetails(Guid? Key) {
            throw new NotImplementedException();
        }
    }
}
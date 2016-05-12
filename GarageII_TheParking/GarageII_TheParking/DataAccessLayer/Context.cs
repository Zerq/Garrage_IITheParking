using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GarageII_TheParking.DataAccessLayer {
    public class Context: DbContext  {

        public Context() : base("DefaultConnection") {}

            public DbSet<Models.Garage> Vehicles { get; set; }
            public DbSet<Models.Vehicle> Garages { get; set; }

    }



}
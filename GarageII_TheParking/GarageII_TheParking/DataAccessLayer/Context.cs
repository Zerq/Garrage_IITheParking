using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GarageII_TheParking.DataAccessLayer {
    public class Context: DbContext  {

        public Context() : base("DefaultConnection") {}

            public DbSet<Models.Vehicle> Vehicle { get; set; }
            public DbSet<Models.Garage> Garage { get; set; }

    }



}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GarageII_TheParking.DataAccessLayer {
    public class Context : DbContext {

        public Context() : base("DefaultConnection") { }

        public DbSet<Models.Vehicle> Vehicle { get; set; }
        public DbSet<Models.Garage> Garage { get; set; }
        public DbSet<Models.Member> Members { get; set; }
        public DbSet<Models.VehicleType> VehicleTypes { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Models.Vehicle>().HasKey(n => n.Id);
            modelBuilder.Entity<Models.Member>().HasKey(n => n.Id);
            modelBuilder.Entity<Models.Garage>().HasKey(n => n.Id);
            modelBuilder.Entity<Models.VehicleType>().HasKey(n => n.Id);
   

            modelBuilder.Entity<Models.Vehicle>()
                .HasRequired<Models.Member>(p => p.PersonWhoParkedVechicle)
                .WithMany(v => v.ParkedVehicle);

            modelBuilder.Entity<Models.Vehicle>()
                .HasRequired<Models.VehicleType>(t => t.Type);


    


        }

    }



}
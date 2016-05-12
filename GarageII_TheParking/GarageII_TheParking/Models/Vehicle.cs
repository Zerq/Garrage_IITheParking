using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageII_TheParking.Models {


    public class Vehicle {
        public Guid Id { get; set; }
        public Colors Color { get; set; }
        public string RegistrationNumber { get; set; }
        public VehicleType Type { get; set; }
        public int WheelCount { get; set; }
        public string Brand { get; set; }
        public DateTime ParkedDate { get; set; }
        public DateTime ExpectedParkOutDate { get; set; }
        public DateTime ParkOutDate { get; set; }
    }



}
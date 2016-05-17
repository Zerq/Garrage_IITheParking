using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GarageII_TheParking.Models {
    // Michael testar att kommentera från GitHub

    [System.Web.Mvc.Bind(Include = "Id,Color,RegistrationNumber,Type,WheelCount,Brand,ParkedDate,ExpectedParkOutDate,ParkOutDate")]
    public class Vehicle {
        public Guid Id { get; set; }
        public Colors Color { get; set; }
        public string RegistrationNumber { get; set; }
        public VehicleType Type { get; set; }
        [Range(0, int.MaxValue)]
        public int WheelCount { get; set; }
        public string Brand { get; set; }
        public DateTime? ParkedDate { get; set; }
        public DateTime? ExpectedParkOutDate { get; set; }
        public Guid GarageId { get; set; }
    }



}

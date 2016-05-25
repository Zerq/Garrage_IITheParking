using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GarageII_TheParking.Models {
    // Michael testar att kommentera från GitHub

    [System.Web.Mvc.Bind(Include = "Id, Color, RegistrationNumber, WheelCount, Brand, ParkedDate, ExpectedParkOutDate, ParkOutDate,PersonWhoParkedVechicle,Type", Exclude = "")]
    public class Vehicle {
        public Guid Id { get; set; }

        [DisplayName("Färg:")]
        public Colors Color { get; set; }

        [DisplayName("Registrationsnummer:")]
        public string RegistrationNumber { get; set; }



        [DisplayName("Antal hjul:")]
        [Range(0, int.MaxValue)]
        public int WheelCount { get; set; }

        [DisplayName("Model:")]
        public string Brand { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}")]

        [DisplayName("Parkerad:")]
        public DateTime? ParkedDate { get; set; }

        [DisplayName("Förväntad tid att lämna garage:")]
        public DateTime? ExpectedParkOutDate { get; set; }

        [DisplayName("GarageId:")]
        public Guid GarageId { get; set; }


        [DisplayName("Typ av fordon:")]
        public VehicleType Type { get; set; }

        [DisplayName("Person som parkerade bilen:")]
        public Member PersonWhoParkedVechicle { get; set; }
    }



}

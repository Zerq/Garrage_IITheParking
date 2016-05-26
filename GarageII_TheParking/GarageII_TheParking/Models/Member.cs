using System;
using System.Collections.Generic;

namespace GarageII_TheParking.Models {

    [System.Web.Mvc.Bind(Include = "Id, Name, LastName, PersonIdNumber, PhoneNr, Address, ParkedVehicle")]
    public class Member {
        public Member() { this.ParkedVehicle = new List<Vehicle>(); }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PersonIdNumber { get; set; }
        public string PhoneNr { get; set; }
        public string Address { get; set; }
        public virtual List<Vehicle> ParkedVehicle { get; set; }
    }
}
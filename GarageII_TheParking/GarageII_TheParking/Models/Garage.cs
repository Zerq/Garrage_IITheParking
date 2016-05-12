using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageII_TheParking.Models {
    public class Garage {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Vehicle> Vehicle { get; set; }
    }
}
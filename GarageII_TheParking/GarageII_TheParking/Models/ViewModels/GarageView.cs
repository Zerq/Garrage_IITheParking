using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageII_TheParking.Models.ViewModels {
    public class GarageViewModel {
        public Garage Garage { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
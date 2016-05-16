﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageII_TheParking.Models {
    public class Garage {
        public Garage() {
            this.Vehicle = new List<Models.Vehicle>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Vehicle> Vehicle { get; set; }
        public int CostPerHour { get; set; } //vad kostar parkeringen?
        public int? CostPerDay { get; set; }
        public int? CostPerWeek { get; set; }
        public int? CostPerMonth { get; set; }
        public int MaxDuration { get; set; }  // hur länge man får parkera.
        // önskas implementering av gratisparkering 

    }
}
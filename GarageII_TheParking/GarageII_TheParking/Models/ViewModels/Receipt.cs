using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageII_TheParking.Models.ViewModels
{
    public class Receipt
    {
        public int CostPerHour { get; set; }
        public int TotalCost { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime TimeWhenPaidParkingTimeExpires { get; set; }
        public DateTime? TimeVehicleCollected { get; set; }

    }
} 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageII_TheParking.Models.ViewModels
{
    public class Receipt
    {
        public int CostPerHour { get; set; }
        public int TotalCost { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}")]
        public DateTime StartTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}")]
        public DateTime TimeWhenPaidParkingTimeExpires { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}")]
        public DateTime? TimeVehicleCollected { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
    }
} 
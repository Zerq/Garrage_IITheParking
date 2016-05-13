using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageII_TheParking.Models.ViewModels
{
    public class Receipt
    {
        public int TimPris { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime PaidTime { get; set; }
        public DateTime EndTime { get; set; }
    }
} 
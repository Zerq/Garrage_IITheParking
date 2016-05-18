using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageII_TheParking.Models.ViewModels
{
                                               
       [System.Web.Mvc.Bind(Include = "Vehicle, AmountTimeToParkDays, AmountTimeToParkTime")]
    public class VehicleAndAmountTimeToPark
    {
        public Vehicle Vehicle { get; set; }

        [DisplayName("Förbetalda dagar och timmar:")]
        public int AmountTimeToParkDays { get; set; }

        [DisplayName("Förbetalda timmar:")]
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
         public TimeSpan AmountTimeToParkTime { get; set; }

    }
}
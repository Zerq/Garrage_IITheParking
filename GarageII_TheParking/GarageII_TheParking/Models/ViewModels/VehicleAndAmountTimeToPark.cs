using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageII_TheParking.Models.ViewModels
{
    [System.Web.Mvc.Bind(Include = "Vehicle,AmountTimeToPark")]
    public class VehicleAndAmountTimeToPark
    {
        public Vehicle Vehicle { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan AmountTimeToPark { get; set; }


    }
}
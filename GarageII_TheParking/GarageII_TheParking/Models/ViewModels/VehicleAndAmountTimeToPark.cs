using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageII_TheParking.Models.ViewModels
{
                                               
       [System.Web.Mvc.Bind(Include = "Vehicle, AmountTimeToParkDays, AmountTimeToParkTime, VehicleType, MemberWhoParkedVehicle", Exclude = "AllTypes, AllMembers")]
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


        public Guid MemberWhoParkedVehicle { get; set; }
        public Guid VehicleType { get; set; }


        public IEnumerable<System.Web.Mvc.SelectListItem> AllTypes { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> AllMembers { get; set; }
    }
}
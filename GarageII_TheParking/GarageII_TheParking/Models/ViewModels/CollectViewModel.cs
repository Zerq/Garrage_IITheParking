using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageII_TheParking.Models.ViewModels
{

    [System.Web.Mvc.Bind(Include = "VehicleId, CollectorId,Error", Exclude = "PersonDropDownOptions")]

    public class CollectViewModel
    {
        public Guid VehicleId { get; set; }
        public Guid CollectorId { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> PersonDropDownOptions { get; set; }
        public string Error { get; set; }
    }
}
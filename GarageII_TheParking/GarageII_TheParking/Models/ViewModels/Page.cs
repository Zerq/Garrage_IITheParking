using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageII_TheParking.Models.ViewModels {
    public class Page<T> {

        public List<T> ItemsOnPage { get; set; }
        public int NumberOfPages { get; set; }
        public int CurrentPageNumber { get; set; }
        public string SortingProperty { get; set; }
        public bool IsDescending { get; set; }
        public string SearchString { get; set; }

	}
}
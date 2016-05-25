using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace GarageII_TheParking.Models.ViewModels {
    public class Page<T> {
        public Page() {
            this.numberOfPages = 0;
            this.itemsOnPage = new List<T>();
            this.CurrentPageNumber = 0;
            this.PageSize = 0;
        }

        public Page(
            int pageSize,
            int currentPageNumber,
            IEnumerable<T> source
           ) {
          
           this.PageSize = pageSize;  
            this.CurrentPageNumber = currentPageNumber;
            this.itemsOnPage = source.Skip(CurrentPageNumber).Take(PageSize).ToList();
            this.numberOfPages = source.Count();
        }
        public int PageSize { get; set; }

        private List<T> itemsOnPage;
        public List<T> ItemsOnPage {
            get {
                return itemsOnPage;
            }
        }

        private int numberOfPages;
        public int NumberOfPages {
            get {

                return numberOfPages; 
                }
        }       

  
        public int CurrentPageNumber { get; set; }

   
   
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace GarageII_TheParking.Models.ViewModels {
 
    public class Page<T> {
        public class PageResult {
            public List<T> Content { get; set; }
            public int PageCount { get; set; }
            public int CurrentPage { get; set; }
        }
        public Page(IEnumerable<T> source, int pageSize, Tuple<string, bool,   
            Func<IEnumerable<T>, IEnumerable<T>>>[] orderParams ,
            Tuple<string, Func<string, IEnumerable<T>, IEnumerable<T>>>[]  searchParams) {
            this.OrderParams = orderParams;
            this.SearchParams = searchParams;
            this.Source = source;
            this.PageSize = pageSize;
        }
        private Tuple<string, Func<string, IEnumerable<T>, IEnumerable<T>>>[] SearchParams;
        private Tuple<string, bool , Func<IEnumerable<T>, IEnumerable<T>>>[] OrderParams;


        public IEnumerable<T> OrderBy(string prop, bool isDescending, IEnumerable<T> items) {
           return this.OrderParams.Single(n => n.Item1 == prop && n.Item2 == isDescending).Item3(items);
        }
        public IEnumerable<T> Search(string Search, string searchProperty, IEnumerable<T> items) {
            return this.SearchParams.Single(n => n.Item1 == searchProperty).Item2(Search, items);
        }

        public PageResult GetPage(int page) {
            return new PageResult() {
                PageCount = Convert.ToInt32(Math.Round((double)(Source.Count() / this.PageSize), MidpointRounding.AwayFromZero)),
                Content = Source.Skip(page * this.PageSize).Take(this.PageSize).ToList(),
                CurrentPage = page
            };
        }
        public PageResult GetPage(int page, string search, string searchProperty) {
            return new PageResult() {
                PageCount = Convert.ToInt32(Math.Round((double)(Source.Count() / this.PageSize), MidpointRounding.AwayFromZero)),
                Content = this.Search(search, searchProperty,Source).Skip(page * this.PageSize).Take(this.PageSize).ToList(),
                CurrentPage = page
            };
        }

        public PageResult GetPage(int page, string OrderByParameter, bool isDescending) {
            return new PageResult() {
                PageCount = Convert.ToInt32(Math.Round((double)(Source.Count() / this.PageSize), MidpointRounding.AwayFromZero)),
                Content = this.OrderBy(OrderByParameter, isDescending, Source).Skip(page * this.PageSize).Take(this.PageSize).ToList(),
                CurrentPage = page
            };
        }
        public PageResult GetPage(int page, string OrderByParameter, bool isDescending, string Search, string searchProperty) {
            return new PageResult() {
                PageCount = Convert.ToInt32(Math.Round((double)(Source.Count() / this.PageSize), MidpointRounding.AwayFromZero)),
                Content = this.OrderBy(OrderByParameter, isDescending, Source).Skip(page * this.PageSize).Take(this.PageSize).ToList(),
                CurrentPage = page
            };

        }

 


        private IEnumerable<T> Source { get; set; } //populated by db context member of matching type
       public int PageSize { get; set; }


    }
}

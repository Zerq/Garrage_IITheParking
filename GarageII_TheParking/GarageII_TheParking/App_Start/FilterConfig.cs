using System.Web;
using System.Web.Mvc;

namespace GarageII_TheParking {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

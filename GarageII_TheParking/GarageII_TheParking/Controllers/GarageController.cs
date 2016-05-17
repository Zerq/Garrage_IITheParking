using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GarageII_TheParking.DataAccessLayer;
using GarageII_TheParking.Models;
using GarageII_TheParking.Handler;

namespace GarageII_TheParking.Controllers
{
    public class GarageController : Controller
    {
        GarageHandler hander = new GarageHandler();

        // GET: Garage
        public ActionResult Index()
        {
            var result = new Models.ViewModels.GarageViewModel() {
                Garage = hander.Garage
            };
            result.Vehicles = hander.ListVehicles(result.Garage);            
            return View(result);
        }

        // GET: Garage/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = hander.GetDetails(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        public ActionResult Park() {
            return View(new Models.ViewModels.VehicleAndAmountTimeToPark() { Vehicle = new Models.Vehicle(), AmountTimeToParkDays =0, AmountTimeToParkTime = new TimeSpan() });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Park( Models.ViewModels.VehicleAndAmountTimeToPark viewModel)
        {
            if (ModelState.IsValid)
            {

                var newTimeSpan = viewModel.AmountTimeToParkTime.Add(new TimeSpan(viewModel.AmountTimeToParkDays, 0, 0, 0));

                var receipt = hander.Park(viewModel.Vehicle, newTimeSpan);
                return View("Receipt", receipt);
            }

            return View(viewModel);
        }
         
        public ActionResult Collect( Guid id) {
                var receipt = hander.Collect(id);

                

                return View("Receipt", receipt);
        }

        protected override void Dispose(bool disposing)
        {

  

            if (disposing)
            {
                hander.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

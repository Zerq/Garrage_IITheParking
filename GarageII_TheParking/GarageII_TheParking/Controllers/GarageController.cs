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
 

        // GET: Garage
        public ActionResult Index()
        {
            var result = new Models.ViewModels.GarageViewModel() {
                Garage = GarageHandler.Instance.Garage
            };
            result.Vehicles = GarageHandler.Instance.ListVehicles(result.Garage);            
            return View(result);
        }

        // GET: Garage/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = Handler.GarageHandler.Instance.GetDetails(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        public ActionResult Park() {
            return View(new Models.ViewModels.VehicleAndAmountTimeToPark() { Vehicle = new Models.Vehicle(), AmountTimeToParkDays = 0, AmountTimeToParkTime = new TimeSpan() });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Park( Models.ViewModels.VehicleAndAmountTimeToPark viewModel)
        {
            if (ModelState.IsValid)
            {
                var apelsin = GarageHandler.Instance.Park(viewModel.Vehicle, new TimeSpan (viewModel.AmountTimeToParkDays, viewModel.AmountTimeToParkTime.Hours, viewModel.AmountTimeToParkTime.Minutes) );
                return View("Receipt", apelsin);
            }

            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Collect([Bind(Include = "Id,Color,RegistrationNumber,Type,WheelCount,Brand")] Vehicle vehicle) {
            if (ModelState.IsValid) {
                var receipt = GarageHandler.Instance.Collect(vehicle);
                return View(receipt);
            }
           
            return View(vehicle);
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Handler.GarageHandler.Close(); // handles disposing the singleton garage handler... sadly this cannot be done with idisposable due to the need to kill of teh singleton instance as well to trigger the creation of a new open dbcontext... otherwise it will end up disposed
            }
            base.Dispose(disposing);
        }
    }
}

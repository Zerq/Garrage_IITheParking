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
            var buffert =  GarageHandler.Instance.Garage;
            buffert.Vehicle = GarageHandler.Instance.ListVehicles(buffert);
            return View(buffert);
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
            return View(new Models.ViewModels.VehicleAndAmountTimeToPark() { Vehicle = new Models.Vehicle(), AmountTimeToPark = new TimeSpan() });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Park( Models.ViewModels.VehicleAndAmountTimeToPark viewModel)
        {
            if (ModelState.IsValid)
            {
                var receipt = GarageHandler.Instance.Park(viewModel.Vehicle, viewModel.AmountTimeToPark );
                return View("Receipt", receipt);
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




        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}

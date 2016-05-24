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
        GarageHandler handler = new GarageHandler();

        // GET: Garage
        public ActionResult Index()
        {
        
            var result = new Models.ViewModels.GarageViewModel() {
                Garage = handler.Garage
            };
            result.Vehicles = handler.ListVehicles(result.Garage);            
            return View(result);
        }

        // GET: Garage/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = handler.GetDetails(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        public ActionResult Park() {
            var members  = handler.GetAllMembers().Select(n => new SelectListItem() { Text =$"{n.Name} {n.LastName}", Value = n.Id.ToString() });
            var types = handler.GetAllVehicleTypes().Select(n => new SelectListItem() { Text = n.Name, Value = n.Id.ToString() });


            return View(new Models.ViewModels.VehicleAndAmountTimeToPark() {
                 AllTypes  =types, 
                AllMembers = members,
                Vehicle = new Models.Vehicle(),
                AmountTimeToParkDays =0,
                AmountTimeToParkTime = new TimeSpan() });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Park( Models.ViewModels.VehicleAndAmountTimeToPark viewModel)
        {

            handler.PopulateFromView(viewModel); 
            if (ModelState.IsValid)
            {
             
                var newTimeSpan = viewModel.AmountTimeToParkTime.Add(new TimeSpan(viewModel.AmountTimeToParkDays, 0, 0, 0));

                var receipt = handler.Park(viewModel.Vehicle, newTimeSpan);
                return View("Receipt", receipt);
            }


            var members = handler.GetAllMembers().Select(n => new SelectListItem() { Text = $"{n.Name} {n.LastName}", Value = n.Id.ToString() });
            var types = handler.GetAllVehicleTypes().Select(n => new SelectListItem() { Text = n.Name, Value = n.Name });

            viewModel.AllMembers = members;
            viewModel.AllTypes = types;

            return View(viewModel);
        }
         
        public ActionResult Collect( Guid id) {
                var receipt = handler.Collect(id);

                

                return View("Receipt", receipt);
        }

        protected override void Dispose(bool disposing)
        {

  

            if (disposing)
            {
                handler.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

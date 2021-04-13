using Microsoft.AspNet.Identity;
using MoveApp.Models;
using MoveApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoveApp.WebMVC.Controllers
{
    [Authorize]
    public class SavedRideController : Controller
    {
        // GET: SavedRide
        public ActionResult Index()
        {
            return View(CreateSavedRideService().GetSavedRideList());
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Saved Ride";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SavedRideCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateSavedRideService().CreateSavedRide(model))
            {
                TempData["SaveResult"] = "Saved Ride established";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error creating Saved Ride");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var savedRide = CreateSavedRideService().GetSavedRideDetailsById(id);
            return View(savedRide);

        }

        public ActionResult Edit(int id)
        {
            var savedRide = CreateSavedRideService().GetSavedRideDetailsById(id);
            return View(new SavedRideEdit
            {
                Id = savedRide.Id,
                Name = savedRide.Name,
                Description = savedRide.Description,
                LocationId = savedRide.LocationId,
                RideStatsId = savedRide.RideStatsId
                
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SavedRideEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Error");
                return View(model);
            }

            if (CreateSavedRideService().UpdateSavedRide(model))
            {
                TempData["SaveResult"] = "Saved Ride updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error editing Saved Ride");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSavedRideService();
            var model = svc.GetSavedRideDetailsById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSavedRide(int id)
        {
            var service = CreateSavedRideService();
            service.DeleteSavedRide(id);
            TempData["SaveResult"] = "Saved Ride deleted";
            return RedirectToAction("Index");
        }

        private SavedRideService CreateSavedRideService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SavedRideService(userId);
            return service;
        }
    }
}
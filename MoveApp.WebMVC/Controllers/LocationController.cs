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
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            return View(CreateLocationService().GetLocationList());
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Location";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateLocationService().CreateLocation(model))
            {
                TempData["SaveResult"] = "Location established";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error creating Location");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var location = CreateLocationService().GetLocationDetailsById(id);
            return View(location);

        }

        public ActionResult Edit(int id)
        {
            var location = CreateLocationService().GetLocationDetailsById(id);
            return View(new LocationEdit
            {
                LocationId = location.LocationId,
                City = location.City,
                State = location.State,
                Park = location.Park
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LocationEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.LocationId != id)
            {
                ModelState.AddModelError("", "Id Error");
                return View(model);
            }

            if (CreateLocationService().UpdateLocation(model))
            {
                TempData["SaveResult"] = "Location updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error editing Location");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateLocationService();
            var model = svc.GetLocationDetailsById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLocation(int id)
        {
            var service = CreateLocationService();
            service.DeleteLocation(id);
            TempData["SaveResult"] = "Location deleted";
            return RedirectToAction("Index");
        }

        private LocationService CreateLocationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LocationService(userId);
            return service;
        }
    }
}

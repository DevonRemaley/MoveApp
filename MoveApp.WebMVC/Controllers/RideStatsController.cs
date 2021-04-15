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
    public class RideStatsController : Controller
    {
        // GET: RideStats
        public ActionResult Index()
        {
            return View(CreateRideStatsService().GetRideStatsList());
        }

        // GET:
        public ActionResult Create()
        {
            ViewBag.Title = "New Ride Stats";
            return View();
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RideStatsCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateRideStatsService().CreateRideStats(model))
            {
                TempData["SaveResult"] = "Ride Stats established";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error creating Ride Stats");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var savedRide = CreateRideStatsService().GetRideStatsDetailsById(id);
            return View(savedRide);

        }

        public ActionResult Edit(int id)
        {
            var rideStats = CreateRideStatsService().GetRideStatsDetailsById(id);
            return View(new RideStatsEdit
            {
                RideStatsId = rideStats.RideStatsId,
                Distance = rideStats.Distance,
                Time = rideStats.Time,
                BikeType = rideStats.BikeType,
            }); ;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RideStatsEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RideStatsId != id)
            {
                ModelState.AddModelError("", "Id Error");
                return View(model);
            }

            if (CreateRideStatsService().UpdateRideStats(model))
            {
                TempData["SaveResult"] = "Ride Stats updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error editing Ride Stats");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRideStatsService();
            var model = svc.GetRideStatsDetailsById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRideStats(int id)
        {
            var service = CreateRideStatsService();
            service.DeleteRideStats(id);
            TempData["SaveResult"] = "Ride Stats deleted";
            return RedirectToAction("Index");
        }

        private RideStatsService CreateRideStatsService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RideStatsService(userId);
            return service;
        }

    }
}
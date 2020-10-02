using SpaceAdventure.Models.Planet;
using SpaceAdventure.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceAdventure.MVC.Controllers
{
    public class PlanetController : Controller
    {
        public PlanetService CreatePlanetService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlanetService(userId);

            return service;
        }
        // GET: Planet
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlanetService(userId);
            var model = service.GetPlanets();

            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlanetCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePlanetService();

            if (service.PlanetCreate(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("List");
            };


            ModelState.AddModelError("", "Note could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePlanetService();
            var model = svc.GetPlanetById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePlanetService();
            var detail = service.GetPlanetById(id);
            var model =
                new PlanetEdit
                {
                    PlanetId = detail.PlanetId,
                    PlanetaryName = detail.PlanetaryName,
                };
            return View(model);
        }
        public ActionResult List(int id)
        {
            var service = CreatePlanetService();
            var list = service.GetPlanetById(id);
            var model =
                new PlanetListItems
                {
                    PlanetId = list.PlanetId,
                    PlanetaryName = list.PlanetaryName,
                    NumOfBadGuys = list.NumOfBadGuys
                };
            return RedirectToAction("List");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlanetEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePlanetService();

            if (service.UpdatePlanet(model))
            {
                TempData["SaveResult"] = "Your Planet was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Planet was not updated");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var service = CreatePlanetService();

            if (service.DeletePlanet(id))
            {
                TempData["SaveResult"] = "Your Planet was deleted.";
                return RedirectToAction("Index");
            }

            TempData["SaveResult"] = "Your Planet was not deleted.";
            return RedirectToAction("Index");

        }
    }
}
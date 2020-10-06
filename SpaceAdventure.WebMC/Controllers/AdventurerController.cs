using SpaceAdventure.Models.Adventurer;
using SpaceAdventure.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceAdventure.MVC.Controllers
{
    public class AdventurerController : Controller
    {
        public AdventurerService CreateAdventurerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AdventurerService(userId);

            return service;
        }
        // GET: Adventurer
        public ActionResult Index()
        {
            var service = CreateAdventurerService();
            var model = service.GetAdventurers();

            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdventurerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAdventurerService();

            if (service.CreateAdventurer(model))
            {
                TempData["SaveResult"] = "Your Adventurer was created.";
                return RedirectToAction($"List");
            };

            ModelState.AddModelError("", "Note could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateAdventurerService();
            var model = svc.GetAdventurerById(id);

            return View(model);
        }

        [HttpGet]
        public ActionResult List()
        {
            var svc = CreateAdventurerService();
            var model = svc.GetAdventurers();

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateAdventurerService();
            var detail = service.GetAdventurerById(id);
            var model =
                new AdventurerEdit
                {
                    AdventurerId = detail.AdventurerId,
                    Name = detail.Name,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdventurerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAdventurerService();

            if (service.UpdateAdventurer(model))
            {
                TempData["SaveResult"] = "Your Adventurer was updated.";
                return RedirectToAction("Details");
            }

            ModelState.AddModelError("", "Your Adventurer was not updated");
            return View(model);
        }
        [HttpGet]
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var service = CreateAdventurerService();

            if (service.DeleteAdventurer(id))
            {
                TempData["SaveResult"] = "Your Adventurer was deleted.";
                return RedirectToAction("Index");
            }

            TempData["SaveResult"] = "Your Adventurer was not deleted.";
            return RedirectToAction("Index");

        }
    }
}

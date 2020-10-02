using SpaceAdventure.Models.BadGuy;
using SpaceAdventure.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceAdventure.MVC.Controllers
{
    public class BadGuyController : Controller
    {
        public BadGuyService CreateBadGuyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BadGuyService(userId);

            return service;
        }
        // GET: BadGuy
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BadGuyService(userId);
            var model = service.GetBadGuys();

            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BadGuyCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateBadGuyService();

            if (service.BadGuyCreate(model))
            {
                TempData["SaveResult"] = "Your Bad Guy was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your Bad Guy could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateBadGuyService();
            var model = svc.GetBadGuyById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateBadGuyService();
            var detail = service.GetBadGuyById(id);
            var model =
                new BadGuyEdit
                {
                    BadGuyId = detail.BadGuyId,
                    Name = detail.Name,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BadGuyEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateBadGuyService();

            if (service.UpdateBadGuy(model))
            {
                TempData["SaveResult"] = "Your Bad Guy was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Bad Guy was not updated");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var service = CreateBadGuyService();

            if (service.DeleteBadGuy(id))
            {
                TempData["SaveResult"] = "Your Bad Guy was deleted.";
                return RedirectToAction("Index");
            }

            TempData["SaveResult"] = "Your Bad Guy was not deleted.";
            return RedirectToAction("Index");

        }
    }
}
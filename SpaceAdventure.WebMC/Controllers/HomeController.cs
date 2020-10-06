using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceAdventure.WebMC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
           
           return View();
        }

        public ActionResult Settings()
        {
            ViewBag.Message = "Settings";

            return View();
        }
        
        public ActionResult Play()
        {
            ViewBag.Message = "Play";

            return View();
        }



    }
}
using AdventureBarn.WorkSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureBarn.WorkSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Support()
        {
            ViewBag.Message = "Contact Form";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Support([Bind(Include = "Name,Email,Telephone, Message")] ContactUs contactUs)
        {
            return View("Index");
        }
    }
}
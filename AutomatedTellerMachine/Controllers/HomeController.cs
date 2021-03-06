﻿using AutomatedTellerMachine.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    [MyLogginFilter]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET /home/index
        [MyLogginFilter]
        [HandleError(View = "Error")]
        [HandleError(View = "ErrorTest", ExceptionType = typeof(OverflowException))]
        [OutputCache(Duration = 60)]
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var checkingAccountId = db.CheckingAccounts.Where(c=>c.ApplicationUserId == userId).First().Id;
            ViewBag.CheckingAccountId = checkingAccountId;
            return View();
        }
        [ActionName("About")]
        // GET /home/about
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View("About");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {
            ViewBag.Message = "Thanks, we got yuour message!";

            return View();
        }

        public ActionResult Serial(string letterCase)
        {
            //var l = HttpUtility.ParseQueryString(Request.Url.Query);
            //if (string.IsNullOrEmpty(letterCase))
            //{
            //    letterCase = l["lowercase"];
            //}
            var serial = "ASPNETMVC5ATM1";
            if (letterCase == "lower")
            {
                return Content(serial);
            }
            //if (letterCase == "lower")
            //{
            //    return Json(new { name = "Test", Value = serial.ToLower() }, JsonRequestBehavior.AllowGet);
            //}
            //return Json(new { name = "Test", Value = serial }, JsonRequestBehavior.AllowGet);

            return RedirectToAction("Index");
        }
    }
}
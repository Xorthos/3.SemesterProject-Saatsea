using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Proxy.Models;

namespace CustomerManagement.Controllers
{
    public class LogController : Controller
    {
        public ActionResult Index()
        {
            List<Log> fakeLogs = new List<Log>();
            return View(fakeLogs);
        }

        public ActionResult LogDetails()
        {
            return View();
        }
    }
}
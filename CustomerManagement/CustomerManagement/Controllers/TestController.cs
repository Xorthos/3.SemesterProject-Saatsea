using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proxy.Authorization;
using Proxy.Models;

namespace CustomerManagement.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View(AuthorizeHttpClient.Register(new RegisterModel() { Email = "Mollls@valls.com", Password = "Balls_3", ConfirmPassword = "Balls_3" }));
        }
    }
}
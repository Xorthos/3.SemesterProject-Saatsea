using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Proxy.Authorization;
using Proxy.Models;
using Proxy.Models.AuthorizationModels;

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
            var thing =
                AuthorizeHttpClient.Register(new RegisterModel()
                {
                    Email = "Bobols@valls.com",
                    Password = "Balls_3",
                    ConfirmPassword = "Balls_3"
                });
            Session["Authorization"] = thing;
            return View(thing);
        }

        public ActionResult GetInfomation()
        {
            string[] result;
            using (var client = AuthorizeHttpClient.GetAuthorizeClient((LoggedInModel) Session["Authorization"]))
            {
                var respond = client.GetAsync(new Uri("http://localhost:2687/api/Values")).Result;
                result = JsonConvert.DeserializeObject<string[]>(respond.Content.ReadAsStringAsync().Result);
            }
            return View(result);
        }
    }
}
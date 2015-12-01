using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Proxy.Facade.Abstraction;
using Proxy.Facade.Implementation;
using Proxy.Models;

namespace CustomerManagement.Controllers
{
    
    public class LogController : Controller
    {
        IFacade facade = new Facade();
        public ActionResult Index()
        {
            return View(facade.GetLogGateway().GetAll());
        }

        public ActionResult LogDetails(int id)
        {
            return View(facade.GetLogGateway().Get(id));
        }
    }
}
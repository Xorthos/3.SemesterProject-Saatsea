using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CustomerManagement.Attributes;
using Proxy.Facade.Abstraction;
using Proxy.Facade.Implementation;
using Proxy.Models;
using Proxy.Models.AuthorizationModels;

namespace CustomerManagement.Controllers
{
    
    public class LogController : Controller
    {
        
        IFacade facade = new Facade();
        [AuthorizeLogin]
        public ActionResult Index()
        {
            
            return View(facade.GetLogGateway((LoggedInModel)Session["LoginModel"]).GetAll());
        }

        [AuthorizeLogin]
        public ActionResult LogDetails(int id)
        {
            return View(facade.GetLogGateway((LoggedInModel)Session["LoginModel"]).Get(id));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CustomerManagement.Attributes;
using CustomerManagement.Models;
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
        public ActionResult Index(SortCriteria? sortCriteria, LogState? logState)
        {
            var result = new SortedLogModel();
                
            if (sortCriteria != null)
            {
                result.SortCriteria = (SortCriteria) sortCriteria;
            }

            if (logState != null)
            {
                result.CurrentState = logState;
            }
            result.Sort(facade.GetLogGateway((LoggedInModel)Session["LoginModel"]).GetAll());
            return View(result);
        }

        [AuthorizeLogin]
        public ActionResult LogDetails(int id)
        {
            return View(facade.GetLogGateway((LoggedInModel)Session["LoginModel"]).Get(id));
        }
    }
}
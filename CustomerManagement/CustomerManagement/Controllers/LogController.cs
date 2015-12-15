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
        public ActionResult Index()
        {
            var result = new SortedLogModel((List<Log>) facade.GetLogGateway((LoggedInModel) Session["LoginModel"]).GetAll());
            if (Request.Form["SortCriteria"] != null)
            {
                foreach (var item in Enum.GetValues(typeof(SortCriteria)))
                {
                    if (item.ToString().Equals(Request.Form["SortCriteria"]))
                    {
                        result.SortCriteria = (SortCriteria) item;
                    }
                }
            }

            if (Request.Form["LogState"] != null)
            {
                foreach (var item in Enum.GetValues(typeof(LogState)))
                {
                    if (item.ToString().Equals(Request.Form["LogState"]))
                    {
                        result.SortCriteria = (SortCriteria)item;
                    }
                }
            }

            return View(result);
        }

        [AuthorizeLogin]
        public ActionResult LogDetails(int id)
        {
            return View(facade.GetLogGateway((LoggedInModel)Session["LoginModel"]).Get(id));
        }
    }
}
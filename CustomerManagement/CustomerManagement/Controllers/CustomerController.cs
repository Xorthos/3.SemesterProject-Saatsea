using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proxy.Facade.Abstraction;
using Proxy.Facade.Implementation;

namespace CustomerManagement.Controllers
{
    public class CustomerController : Controller
    {
        IFacade facade = new Facade();
        // GET: Customer
        public ActionResult Index()
        {
            return View(facade.GetCompanyGateway().GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}
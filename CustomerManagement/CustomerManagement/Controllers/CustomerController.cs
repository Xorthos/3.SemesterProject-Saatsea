using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerManagement.Models;
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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Name, Zipcode, Email, PhoneNr, Password")] CreateCompanyModel newCompanyModel)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Deactivate(int id)
        {
            throw new NotImplementedException();
        }
    }
}
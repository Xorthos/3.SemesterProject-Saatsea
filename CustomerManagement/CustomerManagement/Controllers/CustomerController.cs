﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerManagement.Attributes;
using CustomerManagement.Models;
using Proxy.Facade.Abstraction;
using Proxy.Facade.Implementation;
using Proxy.Models;
using Proxy.Models.AuthorizationModels;

namespace CustomerManagement.Controllers
{

    public class CustomerController : Controller
    {
        private IFacade facade;

        public CustomerController()
        {
            facade = new Facade();
        }
        // GET: Customer
        [AuthorizeLogin]
        public ActionResult Index()
        {
            return View(facade.GetCompanyGateway((LoggedInModel)Session["LoginModel"]).GetAll());
        }

        [AuthorizeLogin]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Create one company
        /// </summary>
        /// <param name="newCompanyModel"></param>
        /// <returns></returns>
        [AuthorizeLogin]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create( CreateCompanyModel newCompanyModel)
        {
            if (ModelState.IsValid)
                facade.GetCompanyGateway((LoggedInModel)Session["LoginModel"]).Add(newCompanyModel.Company);
            else
                return View(newCompanyModel);

            return RedirectToAction("Index");
        }
        /// <summary>
        /// Update one company
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AuthorizeLogin]
        [HttpGet]
        public ActionResult Update(int id) {
            Company theCompany=(facade.GetCompanyGateway((LoggedInModel)Session["LoginModel"]).Get(id));
            return View(theCompany);

        }

        [AuthorizeLogin]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(Company comp)
        {
            facade.GetCompanyGateway((LoggedInModel)Session["LoginModel"]).Update(comp);

           
            return Redirect("Index");

        }



        [AuthorizeLogin]
        public ActionResult Deactivate(int id)
        {
            throw new NotImplementedException();
        }
    }
}
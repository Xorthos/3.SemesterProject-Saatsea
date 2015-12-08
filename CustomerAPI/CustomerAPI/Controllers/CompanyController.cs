using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL.Facade.Abstraction;
using DAL.Facade.Implementation;
using DAL.Models;
using DAL.Repositories.Abstraction;
using Microsoft.AspNet.Identity.EntityFramework;
using DAL.Context;
using Microsoft.AspNet.Identity;
using Context.Models;

namespace CustomerAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CompanyController : ApiController
    {
        private IFacade facade;
        private IRepository<Company> repository; 

        /// <summary>
        /// Constructor: 
        /// </summary>
        public CompanyController()
        {
            facade = new Facade();
            repository = facade.GetCompanyRepository();
        }

        /// <summary>
        /// Get all companies
        /// </summary>
        /// <returns>Returns all companies</returns>
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, repository.GetAll());
            return response;
        }

        /// <summary>
        /// Gets a specific company
        /// </summary>
        /// <param name="id">id of the company</param>
        /// <returns>the company</returns>
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, repository.Get(id));
            return response;
        }

        /// <summary>
        /// adds a given company to the database
        /// </summary>
        /// <param name="comp">the company to add</param>
        /// <returns>the company added with the primary key.</returns>
        [HttpPost]
        public HttpResponseMessage Add(Company comp)
        {
           var password = System.Web.Security.Membership.GeneratePassword(10,10);
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DAL.Context.Context()));
            var user = new ApplicationUser()
            {   

                UserName = comp.Email,
                Email = comp.Email
            };
            
            um.Create(user, password);
            var bytes = System.Text.Encoding.UTF8.GetBytes(comp.Email+":"+ password);
            comp.AccessString = System.Convert.ToBase64String(bytes);
            comp.Active = true;
            var response = Request.CreateResponse(HttpStatusCode.OK, repository.Add(comp));
            return response;
        }

        /// <summary>
        /// updates a company in the database.
        /// </summary>
        /// <param name="comp">the company to be updated</param>
        /// <returns>true if the company was successfully updated</returns>
        [HttpPut]
        public HttpResponseMessage Update(Company comp)
        {
            HttpResponseMessage response;
            if (repository.Update(comp))
            {
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.Conflict);
            }
            
            return response;
        }
    }
}

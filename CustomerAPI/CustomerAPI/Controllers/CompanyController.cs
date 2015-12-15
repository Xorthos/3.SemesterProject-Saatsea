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
using CustomerAPI.Models;

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
            var companyGenerator = new CompanyGenerator();
            var response = Request.CreateResponse(HttpStatusCode.OK, companyGenerator.ParseCompanyRange(repository.GetAll()));
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
            var companyGenerator = new CompanyGenerator();
            var response = Request.CreateResponse(HttpStatusCode.OK, companyGenerator.ParseCompany(repository.Get(id)));
            return response;
        }

        /// <summary>
        /// adds a given company to the database
        /// </summary>
        /// <param name="comp">the company to add</param>
        /// <returns>the company added with the primary key.</returns>
        [HttpPost]
        public HttpResponseMessage Add(ViewCompany comp)
        {
            var companyGenerator = new CompanyGenerator();
            
            var response = Request.CreateResponse(HttpStatusCode.OK, companyGenerator.ParseCompany(repository.Add(companyGenerator.GenerateCompany(comp,15,10))));
            return response;
        }

        /// <summary>
        /// updates a company in the database.
        /// </summary>
        /// <param name="comp">the company to be updated</param>
        /// <returns>true if the company was successfully updated</returns>
        [HttpPut]
        public HttpResponseMessage Update(ViewCompany comp)
        {
            var companyGenerator = new CompanyGenerator();

            var company = companyGenerator.ParseViewCompany(comp);
            HttpResponseMessage response;
            if (repository.Update(company))
            {
                response = Request.CreateResponse(HttpStatusCode.OK, true);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.Conflict);
            }
            
            return response;
        }

        /// <summary>
        /// deActivate company in the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if the company was successfully deActivate</returns>
        [HttpPut]
        [Route("api/company/changestate/{id}")]
        public HttpResponseMessage ChangeState(int id)
        {
            Company comp = repository.Get(id);
            HttpResponseMessage response;
            if (repository.ChangeState(comp))
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

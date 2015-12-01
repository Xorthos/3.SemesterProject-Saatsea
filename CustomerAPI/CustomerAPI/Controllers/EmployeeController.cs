using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using DAL.Facade.Abstraction;
using DAL.Facade.Implementation;
using DAL.Models;
using DAL.Repositories.Abstraction;

namespace CustomerAPI.Controllers
{
    [Authorize]
    public class EmployeeController : ApiController
    {
        private IFacade facade;
        private IRepository<Employee> repository;

        public EmployeeController()
        {
            facade = new Facade();
            repository = facade.GetEmployeeRepository();
        }

        /// <summary>
        /// Gets all the Employees
        /// </summary>
        /// <returns>a list of employees</returns>
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, repository.GetAll());
            return response;
        }

        /// <summary>
        /// Gets a specific employee
        /// </summary>
        /// <param name="id">id of the employee</param>
        /// <returns>the employee with the id</returns>
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, repository.Get(id));
            return response;
        }

        /// <summary>
        /// will add an employee to the database
        /// </summary>
        /// <returns>the employee with the correct primary key</returns>
        [HttpPost]
        public HttpResponseMessage Add(Employee empl)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, repository.Add(empl));
            return response;
        }

        /// <summary>
        /// Will update the employee in the database.
        /// </summary>
        /// <param name="empl">the employee to be updated</param>
        /// <returns>true if it was successfully updated</returns>
        [HttpPut]
        public HttpResponseMessage Update(Employee empl)
        {
            var response = Request.CreateResponse(HttpStatusCode.Accepted, repository.Update(empl));
            return response;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using CustomerAPI.Attributes;
using DAL.Facade.Abstraction;
using DAL.Facade.Implementation;
using DAL.Models;
using DAL.Repositories.Abstraction;

namespace CustomerAPI.Controllers
{
    //[Authorize(Roles = "Admin")]
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
        
        [HttpPost]
        [AllowAnonymous]
        [MyBasicAuthenticationFilter]
        [Route("api/employee/import")]
        public HttpResponseMessage Import(IEnumerable<Employee> Employees)
        {
            if (Employees == null || !Employees.Any())
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            
            Company comp = facade.GetCompanyRepository().Get(Thread.CurrentPrincipal.Identity.Name);
            Log newLog = new Log() {Company = comp, Active = true, Date = DateTime.Now, Import = true, Employees = new List<Employee>()};

            //Runs through every employee from the import list and checks if they are already present in the system.
            bool changesWereMade = false;
            foreach (var emp in Employees)
            {
                //Checks if the employee is already in the system.
                if (!ContainsEmployee(comp, emp))
                {
                    //If it is not in the system the nessecary changes will be made.
                    changesWereMade = true;
                    emp.Company = comp;
                    Employee newEmp = facade.GetEmployeeRepository().Add(emp);
                    comp.Employees.Add(newEmp);
                    newLog.Employees.Add(newEmp);
                }
                
            }

            //If changes were made the company will be updated and the new log will be saved. Otherwise it will be discarded.
            if (changesWereMade)
            {
                facade.GetCompanyRepository().Update(comp);
                facade.GetLogRepository().Add(newLog);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        [AllowAnonymous]
        [MyBasicAuthenticationFilter]
        [Route("api/employee/export")]
        public HttpResponseMessage Export()
        {

            Company comp = facade.GetCompanyRepository().Get(Thread.CurrentPrincipal.Identity.Name);
            Log newLog = new Log() { Company = comp, Active = true, Date = DateTime.Now, Import = false, Employees = comp.Employees };
            facade.GetLogRepository().Add(newLog);

            return Request.CreateResponse(HttpStatusCode.OK, comp.Employees);

        }

        //Checks wether the recieved employee is already within the company list of employees.
        private bool ContainsEmployee(Company comp, Employee emp)
        {
            return comp.Employees.FirstOrDefault(c => c.Address.Equals(emp.Address) && c.BirthDate == emp.BirthDate && c.FirstName.Equals(emp.FirstName) 
            && c.LastName.Equals(emp.LastName) && c.Company.Name.Equals(emp.Company.Name) && c.Phone.Equals(emp.Phone)) != null;
        }
    }
}

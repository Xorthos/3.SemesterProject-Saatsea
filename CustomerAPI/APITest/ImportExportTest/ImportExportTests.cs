using CustomerAPI.Controllers;
using DAL.Models;
using System.Web.Http;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using System.Web.Mvc;
using System.Web.Routing;
using CustomerAPI.Attributes;
using CustomerAPI.BLL;
using Newtonsoft.Json;
using DAL.Context.Repositories.Implementation;
using DAL.Repositories.Implementation;
using DAL.Seed;
using Moq;

namespace APITest.ImportExportTest
{
    [TestFixture]
  public  class ImportExportTests
    {
        public ImportExportTests()
        {
            Initializer.Initalize();
        }

    /// <summary>
    /// Testing there are no employees
    /// </summary>
        [Test]
        public void Import_Logic_With_No_Employees() {
            
            List<Employee> employees = new List<Employee>();
            
            ImportExportLogic imEx = new ImportExportLogic();
            var response = imEx.Import(employees);
            Assert.IsTrue(!response);

        }
         /// <summary>
         /// Import with one employee correctly
         /// </summary>
        [Test]
        public void Import_Logic_With_One_Employee_Correctly() {
            List<Employee> employees = new List<Employee>();
            Employee emp1 = new Employee() {Id = 1000000, FirstName = "TestOneEmp", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-96), Address = "Højvej 22", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", Phone = "56428657", Active = true, Rank = "Programmer" };
            employees.Add(emp1);

            ImportExportLogic imEx = new ImportExportLogic();
            var principal = new GenericPrincipal(new GenericIdentity("random@hej.com"), null);
            Thread.CurrentPrincipal = principal;
            var response = imEx.Import(employees);
            Assert.IsTrue(response);
            CompanyRepository comprepo = new CompanyRepository();
            Company comp = comprepo.Get("random@hej.com");
            EmployeeRepository emprepo = new EmployeeRepository();
            IEnumerable<Employee> emps = emprepo.GetAll();
            Employee emp = emps.FirstOrDefault(c => c.FirstName.Equals("TestOneEmp"));
            Assert.AreEqual(comp.Identity.Email, emp.Company.Identity.Email);
            LogRepository logrepo = new LogRepository();
            IEnumerable<Log> logList = logrepo.GetAll();

            bool containsEmp = false;
            foreach (var log in logList)
            {
                foreach (var logEmp in log.Employees)
                {
                    if (logEmp.FirstName.Equals(emp.FirstName) && log.Import)
                    {
                        containsEmp = true;
                    }
                }
            }

            Assert.IsTrue(containsEmp);

        }

        /// <summary>
        /// Import with multiple employee are correct
        /// </summary>

        [Test]
        public void Import_Logic_With_Multiple_Employees_Correctly()
        {
            List<Employee> employees = new List<Employee>();
            Employee emp1 = new Employee()
            {
                Id = 100002,
                FirstName = "100002 Employee",
                LastName = "Test",
                Active = true,
                Address = "TestRoad",
                BirthDate = DateTime.Now.AddYears(-36),
                City = "Esbjerg",
                Company = null,
                Country = "Denmark",
                ZipCode = 2345,
                Logs = null,
                Rank = "TestGuy",
                Phone = "52634189"

            };
            employees.Add(emp1);
            Employee emp2 = new Employee()
            {
                Id = 100003,
                FirstName = "100003 Employee",
                LastName = "Test",
                Active = true,
                Address = "TestRoad",
                BirthDate = DateTime.Now.AddYears(-36),
                City = "Esbjerg",
                Company = null,
                Country = "Denmark",
                ZipCode = 2345,
                Logs = null,
                Rank = "TestGuy",
                Phone = "52634189"

            };
            employees.Add(emp2);

            ImportExportLogic imEx = new ImportExportLogic();
            var principal = new GenericPrincipal(new GenericIdentity("random@hej.com"), null);
            Thread.CurrentPrincipal = principal;
            var response = imEx.Import(employees);
            Assert.IsTrue(response);
            CompanyRepository comprepo = new CompanyRepository();
            //get the company with Id =1
            Company comp = comprepo.Get("random@hej.com");
            EmployeeRepository emprepo = new EmployeeRepository();
            IEnumerable<Employee> emps = emprepo.GetAll();
            emp1 = emps.FirstOrDefault(c => c.FirstName.Equals("100002 Employee"));
            emp2 = emps.FirstOrDefault(c => c.FirstName.Equals("100003 Employee"));
            Assert.AreEqual(comp.Identity.Email, emp1.Company.Identity.Email);
            Assert.AreEqual(comp.Identity.Email, emp2.Company.Identity.Email);
            LogRepository logrepo = new LogRepository();
            IEnumerable<Log> logList = logrepo.GetAll();

            Log newLog = null;
            bool containsEmp = false;
            foreach (var log in logList)
            {
                foreach (var logEmp in log.Employees)
                {
                    if (logEmp.FirstName.Equals(emp1.FirstName))
                    {
                        newLog = log;

                    }
                }
            }
            if (newLog != null && newLog.Import)
            {
            
            foreach (var logEmp in newLog.Employees)
            {
                if (logEmp.FirstName.Equals(emp2.FirstName))
                {
                    containsEmp = true;
                }
            }
        }

        Assert.IsTrue(containsEmp);
        }

        [Test]
        public void Import_Logic_With_Already_Existing_Employee()
        {
            List<Employee> employees = new List<Employee>();
            //Employee from the seed, which is certain to be in the database alread before the import is done.
            Employee emp1 = new Employee() { Company = null, Id = 1, FirstName = "Hans", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "Højvej 22", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", Phone = "56428657", Active = true, Rank = "Programmer" };

            employees.Add(emp1);

            ImportExportLogic imEx = new ImportExportLogic();
            EmployeeRepository emprepo = new EmployeeRepository();

            var principal = new GenericPrincipal(new GenericIdentity("random@hej.com"), null);
            Thread.CurrentPrincipal = principal;

            int empStartCount = emprepo.GetAll().Count();
            var response = imEx.Import(employees);
            Assert.IsTrue(response);

            int empEndCount = emprepo.GetAll().Count();
            Assert.AreEqual(empStartCount, empEndCount);

            IEnumerable<Employee> emps = emprepo.GetAll();
            Employee emp = emps.FirstOrDefault(c => c.FirstName.Equals("Hans"));
            Assert.IsTrue(emp != null);
        }

        [Test]
        public void Import_Controller_Method_No_Employees()
        {
            List<Employee> employees = new List<Employee>();

            var principal = new GenericPrincipal(new GenericIdentity("random@hej.com"), null);
            Thread.CurrentPrincipal = principal;

            var response = FakeImportRequest(employees);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Test]
        public void Import_Controller_Method_With_Employees()
        {
            List<Employee> employees = new List<Employee>();
            Employee emp1 = new Employee() { Id = 1000000, FirstName = "TestOneEmp1", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-96), Address = "Højvej 22", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", Phone = "56428657", Active = true, Rank = "Programmer" };
            employees.Add(emp1);

            var principal = new GenericPrincipal(new GenericIdentity("random@hej.com"), null);
            Thread.CurrentPrincipal = principal;

            var response = FakeImportRequest(employees);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void Export_Logic_With_Employees()
        {
            //We fake a login from a company that we know have 5 employees, but has never done a export before.
            var principal = new GenericPrincipal(new GenericIdentity("douche@hej.com"), null);
            Thread.CurrentPrincipal = principal;

            ImportExportLogic imEx = new ImportExportLogic();
            var response = imEx.Export();
            //The number of expected employees are compared to the actual number of employees for the given company.
            Assert.AreEqual(5, response.Count);

            LogRepository logrepo = new LogRepository();
            IEnumerable<Log> logList = logrepo.GetAll();

            bool logCreated = false;
            foreach (var log in logList)
            {
                if (!log.Import && log.Company.Identity.Email.Equals("douche@hej.com") && log.Employees.Count == 5)
                {
                    logCreated = true;
                }
            }

            Assert.IsTrue(logCreated);

        }

        [Test]
        public void Export_Logic_With_No_Employees()
        {
            //We fake a login from a company that we know have 0 employees, but has never done a export before.
            var principal = new GenericPrincipal(new GenericIdentity("house@hej.com"), null);
            Thread.CurrentPrincipal = principal;

            ImportExportLogic imEx = new ImportExportLogic();
            var response = imEx.Export();
            //The number of expected employees are compared to the actual number of employees for the given company.
            Assert.AreEqual(0, response.Count);

            LogRepository logrepo = new LogRepository();
            IEnumerable<Log> logList = logrepo.GetAll();

            bool logCreated = false;
            foreach (var log in logList)
            {
                if (!log.Import && log.Company.Identity.Email.Equals("house@hej.com") && log.Employees.Count == 0)
                {
                    logCreated = true;
                }
            }

            Assert.IsTrue(logCreated);

        }

        [Test]
        public void Export_Controller_Method_With_Employees()
        {
            //We fake a login from a company that we know have 5 employees.
            var principal = new GenericPrincipal(new GenericIdentity("douche@hej.com"), null);
            Thread.CurrentPrincipal = principal;
            
            var response = FakeExportRequest();
            List<Employee> emps = JsonConvert.DeserializeObject<List<Employee>>(response.Content.ReadAsStringAsync().Result);
            //The number of expected employees are compared to the actual number of employees for the given company.
            Assert.AreEqual(5, emps.Count);

        }

        [Test]
        public void Export_Controller_Method_With_No_Employees()
        {
            //We fake a login from a company that we know have 0 employees.
            var principal = new GenericPrincipal(new GenericIdentity("house@hej.com"), null);
            Thread.CurrentPrincipal = principal;
            
            var response = FakeExportRequest();
            
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);

        }

        private HttpResponseMessage FakeExportRequest()
        {
            EmployeeController empcont = new EmployeeController();
            var controller = new EmployeeController();
            var config = new HttpConfiguration();
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/api/employee/export");
            var route = config.Routes.MapHttpRoute("export", "api/{controller}/{id}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "employee" } });

            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;

            // Call your method to test
            return controller.Export();
        }

        private HttpResponseMessage FakeImportRequest(List<Employee> employees )
        {
            EmployeeController empcont = new EmployeeController();
            var controller = new EmployeeController();
            var config = new HttpConfiguration();
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/employee/import");
            var route = config.Routes.MapHttpRoute("import", "api/{controller}/{id}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "employee" } });

            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;

            // Call your method to test
            return controller.Import(employees);
        }
    }
}

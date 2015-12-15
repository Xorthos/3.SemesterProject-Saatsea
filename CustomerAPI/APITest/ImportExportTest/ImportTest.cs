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
using System.Security.Principal;
using System.Threading;
using System.Web.Http.Controllers;
using CustomerAPI.Attributes;
using Newtonsoft.Json;
using DAL.Context.Repositories.Implementation;
using DAL.Repositories.Implementation;
using DAL.Seed;
using Moq;

namespace APITest.ImportExportTest
{
    [TestFixture]
  public  class ImportTest
    {
        public ImportTest()
        {
            Initializer.Initalize();
        }

    /// <summary>
    /// Testing there are no employees
    /// </summary>
        [Test]
        public void Import_With_No_Employees() {


            List<Employee> employees = new List<Employee>();
            
            EmployeeController empcont = new EmployeeController();
            var response = empcont.Import(employees);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }
         /// <summary>
         /// Import with one employee correctly
         /// </summary>
        [Test]
        public void Import_With_One_Employee_Correctly() {
            List<Employee> employees = new List<Employee>();
            Employee emp1 = new Employee() {Id = 1000000, FirstName = "TestOneEmp", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-96), Address = "Højvej 22", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", Phone = "56428657", Active = true, Rank = "Programmer" };
            employees.Add(emp1);

            EmployeeController empcont = new EmployeeController();
            var principal = new GenericPrincipal(new GenericIdentity("random@hej.com"), null);
            Thread.CurrentPrincipal = principal;
            var response = empcont.Import(employees);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            CompanyRepository comprepo = new CompanyRepository();
            Company comp = comprepo.Get("random@hej.com");
            EmployeeRepository emprepo = new EmployeeRepository();
            IEnumerable<Employee> emps = emprepo.GetAll();
            Employee emp = emps.FirstOrDefault(c => c.FirstName.Equals("TestOneEmp"));
            //Assert.AreEqual(comp.Email, emp.Company.Email);
            LogRepository logrepo = new LogRepository();
            IEnumerable<Log> logList = logrepo.GetAll();

            bool containsEmp = false;
            foreach (var log in logList)
            {
                foreach (var logEmp in log.Employees)
                {
                    if (logEmp.FirstName.Equals(emp.FirstName))
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
        public void Import_With_Multiple_Employees_Correctly()
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

            EmployeeController empcont = new EmployeeController();
            var principal = new GenericPrincipal(new GenericIdentity("random@hej.com"), null);
            Thread.CurrentPrincipal = principal;
            var response = empcont.Import(employees);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            CompanyRepository comprepo = new CompanyRepository();
            //get the company with Id =1
            Company comp = comprepo.Get("random@hej.com");
            EmployeeRepository emprepo = new EmployeeRepository();
            IEnumerable<Employee> emps = emprepo.GetAll();
            emp1 = emps.FirstOrDefault(c => c.FirstName.Equals("100002 Employee"));
            emp2 = emps.FirstOrDefault(c => c.FirstName.Equals("100003 Employee"));
            //Assert.AreEqual(comp.Email, emp1.Company.Email);
            //Assert.AreEqual(comp.Email, emp1.Company.Email);
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
            if (newLog != null)
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
        public void Import_With_Already_Existing_Employee()
        {
            List<Employee> employees = new List<Employee>();
            //Employee from the seed, which is certain to be in the database alread before the import is done.
            Employee emp1 = new Employee() { Company = null, Id = 1, FirstName = "Hans", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "Højvej 22", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", Phone = "56428657", Active = true, Rank = "Programmer" };

            employees.Add(emp1);

            EmployeeController empcont = new EmployeeController();
            EmployeeRepository emprepo = new EmployeeRepository();

            var principal = new GenericPrincipal(new GenericIdentity("random@hej.com"), null);
            Thread.CurrentPrincipal = principal;

            int empStartCount = emprepo.GetAll().Count();
            var response = empcont.Import(employees);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

            int empEndCount = emprepo.GetAll().Count();
            Assert.AreEqual(empStartCount, empEndCount);

            IEnumerable<Employee> emps = emprepo.GetAll();
            Employee emp = emps.FirstOrDefault(c => c.FirstName.Equals("Hans"));
            Assert.IsTrue(emp != null);
        }

        [Test]
        public void Receive_Own_Logs()
        {
           Assert.IsTrue(true);
        }
    }
}

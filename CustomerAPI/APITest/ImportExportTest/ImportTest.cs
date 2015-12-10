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
using System.Web.Http.Controllers;
using Newtonsoft.Json;
using DAL.Context.Repositories.Implementation;
using DAL.Repositories.Implementation;
using Moq;

namespace APITest.ImportExportTest
{
    [TestFixture]
  public  class ImportTest
    {

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
            var response = empcont.Import(employees);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            CompanyRepository comprepo = new CompanyRepository();
            //get the company with Id =1
            Company comp = comprepo.Get(1);
            EmployeeRepository emprepo = new EmployeeRepository();
            Employee emp = emprepo.Get(1000000);
            Assert.AreEqual(comp, emp.Company);
            LogRepository logrepo = new LogRepository();
            IEnumerable<Log> logList = logrepo.GetAll();

            Log log = logList.Where(l => l.Company.Equals(comp)).Where(l => l.Import = true).FirstOrDefault(l => l.Employees.Contains(emp));

            Assert.IsTrue(log != null);

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

            };
            employees.Add(emp1);
            Employee emp2 = new Employee()
            {
                Id = 100003,
                FirstName = "100003 Employee",

            };
            employees.Add(emp2);

            EmployeeController empcont = new EmployeeController();
            var response = empcont.Import(employees);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            CompanyRepository comprepo = new CompanyRepository();
            //get the company with Id =1
            Company comp = comprepo.Get(2);
            EmployeeRepository emprepo = new EmployeeRepository();
            emp1 = emprepo.Get(100002);
            emp2 = emprepo.Get(100003);
            Assert.AreEqual(comp, emp1.Company);
            Assert.AreEqual(comp, emp2.Company);
            LogRepository logrepo = new LogRepository();
            IEnumerable<Log> logList = logrepo.GetAll();

            Log log = logList.Where(l => l.Company.Equals(comp)).Where(l => l.Import = true).Where(l => l.Employees.Contains(emp1)).FirstOrDefault((l => l.Employees.Contains(emp2)));

            Assert.IsTrue(log != null);
        }

        [Test]
        public void Import_With_Already_Existing_Employee()
        {
            List<Employee> employees = new List<Employee>();
            Employee emp1 = new Employee()
            {
                Id = 100001,
                FirstName = "100001 Employee",

            };
            employees.Add(emp1);

            EmployeeController empcont = new EmployeeController();
            var response = empcont.Import(employees);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

            response = empcont.Import(employees);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

            CompanyRepository comprepo = new CompanyRepository();
            //get the company with Id =1
            Company comp = comprepo.Get(1);
            EmployeeRepository emprepo = new EmployeeRepository();
            Employee emp = emprepo.Get(100001);
            Assert.AreEqual(comp, emp.Company);
            LogRepository logrepo = new LogRepository();
            IEnumerable<Log> logList = logrepo.GetAll();

            Log log = logList.Where(l => l.Company.Equals(comp)).Where(l => l.Import = true).FirstOrDefault(l => l.Employees.Contains(emp));

            Assert.IsTrue(log != null);
        }

        [Test]
        public void Receive_Own_Logs() {
            Assert.AreEqual(true, false);
        }
    }
}

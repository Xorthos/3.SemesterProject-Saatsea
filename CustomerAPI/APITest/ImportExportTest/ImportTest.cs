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
using Newtonsoft.Json;
using DAL.Context.Repositories.Implementation;
using DAL.Repositories.Implementation;

namespace DALTest.ImportExportTest
{
    [TestFixture]
  public  class ImportTest
    {
       
        [Test]
        public void Import_Where_Company_Does_Not_Exist() {

            List<Employee> employees = new List<Employee>();
            Employee emp1 = new Employee()
            {
                Id = 100,
                FirstName = "101 Employee",

            };
            Employee emp2 = new Employee()
            {
                Id = 101,
                FirstName = "102 Employee",

            };
            employees.Add(emp1);
            employees.Add(emp2);

            EmployeeController empcont = new EmployeeController();
            
           var response=empcont.Import(2000, employees);
           Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
            
        }

    /// <summary>
    /// Testing there are no employees
    /// </summary>
        [Test]
        public void Import_With_No_Employees() {


            List<Employee> employees = new List<Employee>();
            
            EmployeeController empcont = new EmployeeController();
            var response = empcont.Import(1, employees);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }
         /// <summary>
         /// Import with one employee correctly
         /// </summary>
        [Test]
        public void Import_With_One_Employee_Correctly() {
            List<Employee> employees = new List<Employee>();
            Employee emp1 = new Employee()
            {
                Id = 98789,
                FirstName = "101 Employee",
             
            };
            employees.Add(emp1);

            EmployeeController empcont = new EmployeeController();
            var response = empcont.Import(1, employees);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            CompanyRepository comprepo = new CompanyRepository();
            //get the company with Id =1
            Company comp = comprepo.Get(1);
            EmployeeRepository emprepo = new EmployeeRepository();
            Employee emp = emprepo.Get(98789);
            Assert.AreEqual(comp,emp.Company);
            LogRepository logrepo = new LogRepository();
            IEnumerable<Log> logList = logrepo.GetAll();

            Log log = logList.Where(l => l.Company == comp).Where(l => l.Employees.Contains(emp)).FirstOrDefault();

            Assert.IsTrue(log!=null);

        }
         /// <summary>
         /// Import with multiple employee are correct
         /// </summary>

        [Test]
        public void Import_With_Multiple_Employees_Correctly() { }

        [Test]
        public void Import_With_MisMatching_Company_Data() { }

        [Test]
        public void Import_With_Already_Existing_Employee() { }

        [Test]
        public void Receive_Own_Logs() { }
    }
}

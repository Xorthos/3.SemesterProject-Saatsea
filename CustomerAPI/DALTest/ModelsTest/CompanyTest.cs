using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context.Models;

namespace DALTest.ModelsTest
{
    [TestFixture]
   public class CompanyTest
    {
        ///<summary>
        /// Test getters and setters
        /// </summary>

        [Test]
        public void Getters_And_Setters_Test()
        {
            List<Employee> employees = new List<Employee>();
            Employee emp1 = new Employee()
            {
                ID = 1,
                Name = "First Employee",
                CompanyID = 1
            };
            Employee emp2 = new Employee()
            {
                ID = 1,
                Name = "First Employee",
                CompanyID = 1
            };
            employees.Add(emp1);
            employees.Add(emp2);


            Company comp = new Company() {
                ID = 1,
                Name = "Big Company",
                Zipcode =6700,
                Address = "Test Street 7",
                Email= "something@gmail.com",
                PhoneNr = "12345678",
                Employees = employees,

        };

            Assert.AreEqual(comp.ID, 1);
            Assert.AreEqual(comp.Name, "Big Company");
            Assert.AreEqual(comp.Zipcode, 6700);
            Assert.AreEqual(comp.Address, "Test Street 7");
            Assert.AreEqual(comp.Email,"something@gmail.com");
            Assert.AreEqual(comp.PhoneNr, "12345678");
            Assert.AreEqual(comp.Employees, employees);
        }

        [Test]
        public void Test()
        {
            Assert.AreNotEqual(1,3);
    }

    }
 
}

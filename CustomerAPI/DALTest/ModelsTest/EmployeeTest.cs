using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Context.Models;

namespace DALTest.ModelsTest
{
    [TestFixture]
    public class EmployeeTest
    {
        ///<summary>
        /// Test getters and setters
        /// </summary>

        [Test]
        public void Getters_And_Setters_Test()
        {
            //Company comp = new Company()
            //{
            //    ID = 1,
            //    Name = "Big Company",
            //    Zipcode = 6700,
            //    Address = "Test Street 7",
            //    Email = "something@gmail.com",
            //    PhoneNr = "12345678",

            //};
            Employee emp = new Employee()
            {
                ID = 1,
                Name = "First Employee",
                CompanyID = 1

            };

            Assert.AreEqual(emp.ID, 1);
            Assert.AreEqual(emp.Name, "First Employee");
            Assert.AreEqual(emp.CompanyID, 1);
        }
    }
}

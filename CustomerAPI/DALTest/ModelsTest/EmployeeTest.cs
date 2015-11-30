using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DAL.Models;

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
            
            Company comp = new Company()
            {
                Id = 1,
                Name = "Big Company",
                Zipcode = 6700,
                Email = "something@gmail.com",
                PhoneNr = "12345678",
                Active = true,

            };
            Employee emp = new Employee()
            {
                Id = 1,
                FirstName = "First ",
                LastName = "Employee",
                Country = "Denmark",
                ZipCode = 6700,
                City = "Esbjerg",
                Address = "This Vej 7",
                BirthDate = DateTime.Now.Date,
                Rank = "Captain",
                Phone = "1111111",
                Company = comp,
                Active =true
            };

            Assert.AreEqual(emp.Id, 1);
            Assert.AreEqual(emp.FirstName, "First ");
            Assert.AreEqual(emp.LastName, "Employee");
            Assert.AreEqual(emp.Country, "Denmark");
            Assert.AreEqual(emp.ZipCode, 6700);
            Assert.AreEqual(emp.City, "Esbjerg");
            Assert.AreEqual(emp.Address, "This Vej 7");
            Assert.AreEqual(emp.BirthDate, DateTime.Now.Date);
            Assert.AreEqual(emp.Rank, "Captain");
            Assert.AreEqual(emp.Phone,"1111111");
            Assert.AreEqual(emp.Company, comp);
            Assert.IsTrue(emp.Active);
        }

        [Test]

        public void Employee_With_The_Same_Id_Should_Be_Equal_Test()
        {
            Employee emp1 = new Employee {Id = 1 };
            Employee emp2 = new Employee {Id = 1 };

            Assert.AreEqual(emp1, emp2);
            Assert.AreEqual(emp1.GetHashCode(),emp2.GetHashCode());
        }

        [Test] public void Employee_With_Different_Id_Should_Be_Unequal_And_Have_Different_HashCode_Test()
        {
            Employee emp1 = new Employee { Id = 1 };
            Employee emp2 = new Employee { Id = 2 };

            Assert.AreNotEqual(emp1, emp2);
            Assert.AreNotEqual(emp1.GetHashCode(), emp2.GetHashCode());
        }
    }
}

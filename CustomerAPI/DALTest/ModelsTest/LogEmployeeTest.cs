using Context.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTest.ModelsTest
{   
    [TestFixture]
    class LogEmployeeTest
    {   
        [Test]
        public void Getters_And_Setters_Test()
        {
            Company comp = new Company()
            {
                ID = 1,
                Name = "Big Company",
                Zipcode = 6700,
                Address = "Test Street 7",
                Email = "something@gmail.com",
                PhoneNr = "12345678",

            };
            Employee emp = new Employee()
            {
                ID = 1,
                Name = "First Employee",
                CompanyID = comp.ID

            };
          
            Log log = new Log()
            {
                ID = 1,
                CompanyID = comp.ID,
                Date = DateTime.Now.Date,
                Import = true,

            };
            Assert.AreEqual(log.ID, 1);
            Assert.AreEqual(log.CompanyID, comp.ID);
            Assert.AreEqual(log.Date, DateTime.Now.Date);
            Assert.AreEqual(log.Import, true);

            
        }



    }
}

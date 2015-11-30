using NUnit.Framework;
using System;
using DAL.Models;
using NUnit.Core;


namespace DALTest.ModelsTest
{

    [TestFixture]
    class LogTest
    {   
        [Test]
        public void Getters_And_Setters_Test()
        {
            Company comp = new Company()
            {
                Id = 1,
                Name = "Big Company",
                Zipcode = 6700,
                //Address = "Test Street 7",
                Email = "something@gmail.com",
                PhoneNr = "12345678",
                Active = true,

            };
            Employee emp = new Employee()
            {
                Id = 1,
                Name = "First Employee",
                Company = comp,

            };
          
            Log log = new Log()
            {
                Id = 1,
                Company= comp,
                Date = DateTime.Now.Date,
                Import = true,

            };
            Assert.AreEqual(log.Id, 1);
            Assert.AreEqual(log.Company, comp);
            Assert.AreEqual(log.Date, DateTime.Now.Date);
            Assert.AreEqual(log.Import, true);
        }




    }
}

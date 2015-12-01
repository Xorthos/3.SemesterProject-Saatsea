using NUnit.Framework;
using System;
using DAL.Models;
using NUnit.Core;
using System.Collections.Generic;

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

            List<Employee> employees = new List<Employee>();
            Employee emp1 = new Employee()
            {
                Id = 1,
                FirstName = "First Employee",

            };
            Employee emp2 = new Employee()
            {
                Id = 1,
                FirstName = "First Employee",

            };
            employees.Add(emp1);
            employees.Add(emp2);



            Log log = new Log()
            {
                Id = 1,
                Company = comp,
                Date = DateTime.Now.Date,
                Import = true,
                Employees = employees,
                Active=true


            };
            Assert.AreEqual(log.Id, 1);
            Assert.AreEqual(log.Company, comp);
            Assert.AreEqual(log.Date, DateTime.Now.Date);
            Assert.AreEqual(log.Import, true);
            Assert.AreEqual(log.Employees, employees);
            Assert.AreEqual(log.Active, true);

        }




    }
}

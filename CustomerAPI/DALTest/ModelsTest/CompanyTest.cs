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
            Company comp = new Company() {
                ID = 1,
                Name = "Big Company",
                Zipcode =6700,
                Address = "Test Street 7",
                Email= "something@gmail.com",
                PhoneNr = "12345678",
     
            };

            Assert.AreEqual(comp.ID, 1);
            Assert.AreEqual(comp.Name, "Big Company");
            Assert.AreEqual(comp.Zipcode, 6700);
            Assert.AreEqual(comp.Address, "Test Street 7");
            Assert.AreEqual(comp.Email,"something@gmail.com");
            Assert.AreEqual(comp.PhoneNr, "12345678");
        }
        
    }
}

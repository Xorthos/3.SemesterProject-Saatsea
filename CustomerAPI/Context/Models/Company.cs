using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Zipcode { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}

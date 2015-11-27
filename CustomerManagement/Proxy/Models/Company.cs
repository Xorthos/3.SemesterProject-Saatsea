using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Zipcode { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; }
        public List<Employee> Employees  { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context.Models
{
    public class Company
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public int Zipcode { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; }
        public List<Employee> Employees {get; set; }
        public bool Active { get; set; }

        public override bool Equals(object obj)
        {
            return Id==(obj as Company).Id;
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(Id);
        }
    }

    
}

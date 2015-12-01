using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Models
{
  public class Employee
    {
        public string FirstName { get; set; }
        public string Country { get; set; }
        public string LastName { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Rank { get; set; }
        public string Phone { get; set; }

        public int Id { get; set; }
        public virtual Company Company { get; set; }
        public bool Active { get; set; }


        public override bool Equals(object emp)
        {
            return Id == (emp as Employee).Id;
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(Id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Models
{
  public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual Company Company { get; set; }
    }
}

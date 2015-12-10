using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Models
{
  public class Log
    {
        public int ID { get; set; }
        public virtual Company Company { get; set; }
        public DateTime Date { get; set; }
        public bool Import { get; set; }
        public List<Employee> Employees  { get; set; }
        public bool Active { get; set; }

    }
}

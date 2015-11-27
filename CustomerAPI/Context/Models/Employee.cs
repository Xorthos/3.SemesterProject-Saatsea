using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
  public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual Company Company { get; set; }
        public virtual List<Log> Logs { get; set; }
        public bool Active { get; set; }
    }
}

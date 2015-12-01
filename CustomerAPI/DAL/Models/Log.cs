﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
  public class Log
    {
        public int Id { get; set; }
        public virtual Company Company { get; set; }
        public DateTime Date { get; set; }
        public bool Import { get; set; }
        public virtual List<Employee> Employees { get; set; }
        public bool Active { get; set; }
    }
}
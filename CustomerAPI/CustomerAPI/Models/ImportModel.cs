using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;

namespace CustomerAPI.Models
{
    public class ImportModel
    {
        public string CompanyEmail { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
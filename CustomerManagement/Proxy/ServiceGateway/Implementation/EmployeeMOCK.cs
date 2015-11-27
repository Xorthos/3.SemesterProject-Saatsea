using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxy.Models;
using Proxy.ServiceGateway.Abstraction;

namespace Proxy.ServiceGateway.Implementation
{
    class EmployeeMOCK : ServiceGateway<Employee>
    {
        public override Employee Add(Employee item)
        {
            MOCKData.employees.Add(item);
            return item;
        }

        public override IEnumerable<Employee> GetAll()
        {
            return MOCKData.employees;
        }

        public override Employee Get(int id)
        {
            return MOCKData.employees.FirstOrDefault(em => em.ID == id);
        }

        public override bool Update(Employee item)
        {
            Employee emp = MOCKData.employees.FirstOrDefault(em => em.ID == item.ID);
            emp.ID = item.ID;
            emp.Company = item.Company;
            emp.Name = item.Name;
            return true;
        }
    }
}

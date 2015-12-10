using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxy.Models;
using Proxy.Models.AuthorizationModels;
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
            return MOCKData.employees.FirstOrDefault(em => em.Id == id);
        }

        public override bool Update(Employee item)
        {
            Employee emp = MOCKData.employees.FirstOrDefault(em => em.Id== item.Id);
            emp.Id = item.Id;
            emp.Company = item.Company;
            emp.Active = item.Active;
            emp.Address = item.Address;
            emp.BirthDate = item.BirthDate;
            emp.City = item.City;
            emp.Country = item.Country;
            emp.FirstName = item.FirstName;
            emp.LastName = item.LastName;
            emp.Phone = item.Phone;
            emp.Rank = item.Rank;
            emp.ZipCode = item.ZipCode;
            return true;
        }

        public override bool ChangeState(int id)
        {
            throw new NotImplementedException();
        }

        public EmployeeMOCK(LoggedInModel model) : base(model)
        {
        }
    }
}

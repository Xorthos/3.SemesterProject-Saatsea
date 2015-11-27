using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxy.Models;
using Proxy.ServiceGateway.Abstraction;

namespace Proxy.ServiceGateway.Implementation
{
    class CompanyMOCK : ServiceGateway<Company>
    {
        public override Company Add(Company item)
        {
            MOCKData.companies.Add(item);
            return item;
        }

        public override IEnumerable<Company> GetAll()
        {
            return MOCKData.companies;
        }

        public override Company Get(int id)
        {
            return MOCKData.companies.FirstOrDefault(cm => cm.ID == id);
        }

        public override bool Update(Company item)
        {
            Company comp = MOCKData.companies.FirstOrDefault(cm => cm.ID == item.ID);
            comp.Employees = item.Employees;
            comp.Email = item.Email;
            comp.Name = item.Name;
            comp.PhoneNr = item.PhoneNr;
            comp.Zipcode = item.Zipcode;
            return true;
        }
    }
}

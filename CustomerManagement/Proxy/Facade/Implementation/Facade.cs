using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxy.Facade.Abstraction;
using Proxy.Models;
using Proxy.ServiceGateway.Abstraction;
using Proxy.ServiceGateway.Implementation;

namespace Proxy.Facade.Implementation
{
    public class Facade : IFacade
    {
        public ServiceGateway<Company> GetCompanyGateway()
        {
            return new CompanyGateway();
        }

        public ServiceGateway<Employee> GetEmployeeGateway()
        {
            return new EmployeeGateway();
        }

        public ServiceGateway<Log> GetLogGateway()
        {
            return new LogGateway();
        }
    }
}

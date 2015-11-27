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
    public class FacadeMOCK : IFacade
    {
        public ServiceGateway<Company> GetCompanyGateway()
        {
            return new CompanyMOCK();
        }

        public ServiceGateway<Employee> GetEmployeeGateway()
        {
            return new EmployeeMOCK();
        }

        public ServiceGateway<Log> GetLogGateway()
        {
            return new LogMOCK();
        }
    }
}

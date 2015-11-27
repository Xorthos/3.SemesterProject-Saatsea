using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxy.Models;
using Proxy.ServiceGateway.Abstraction;

namespace Proxy.Facade.Abstraction
{
    public interface IFacade
    {
        ServiceGateway<Company> GetCompanyGateway();
        ServiceGateway<Employee> GetEmployeeGateway();
        ServiceGateway<Log> GetLogGateway();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxy.Models;
using Proxy.Models.AuthorizationModels;
using Proxy.ServiceGateway.Abstraction;

namespace Proxy.Facade.Abstraction
{
    public interface IFacade
    {
        ServiceGateway<Company> GetCompanyGateway(LoggedInModel model);
        ServiceGateway<Employee> GetEmployeeGateway(LoggedInModel model);
        ServiceGateway<Log> GetLogGateway(LoggedInModel model);
    }
}

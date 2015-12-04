using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxy.Facade.Abstraction;
using Proxy.Models;
using Proxy.Models.AuthorizationModels;
using Proxy.ServiceGateway.Abstraction;
using Proxy.ServiceGateway.Implementation;

namespace Proxy.Facade.Implementation
{
    public class Facade : IFacade
    {
        public ServiceGateway<Company> GetCompanyGateway(LoggedInModel model)
        {
            return new CompanyGateway(model);
        }

        public ServiceGateway<Employee> GetEmployeeGateway(LoggedInModel model)
        {
            return new EmployeeGateway(model);
        }

        public ServiceGateway<Log> GetLogGateway(LoggedInModel model)
        {
            return new LogGateway(model);
        }
    }
}

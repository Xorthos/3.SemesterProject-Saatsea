using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repositories.Abstraction;

namespace DAL.Facade.Abstraction
{
    public interface IFacade
    {
        IRepository<Log> GetLogRepository();
        IRepository<Employee> GetEmployeeRepository();
        IRepository<Company> GetCompanyRepository();
    }
}

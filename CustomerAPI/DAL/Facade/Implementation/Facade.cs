using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context.Repositories.Implementation;
using DAL.Facade.Abstraction;
using DAL.Models;
using DAL.Repositories.Abstraction;
using DAL.Repositories.Implementation;

namespace DAL.Facade.Implementation
{
    public class Facade : IFacade
    {
        /// <summary>
        /// Creates a logrepository and returns it
        /// </summary>
        /// <returns>a logrepository</returns>
        public IRepository<Log> GetLogRepository()
        {
            return new LogRepository();
        }

        /// <summary>
        /// Creates a EmployeeRepository and returns it
        /// </summary>
        /// <returns>a EmployeeRepository</returns>
        public IRepository<Employee> GetEmployeeRepository()
        {
            return new EmployeeRepository();
        }

        /// <summary>
        /// Creates a CompanyRepository and returns it
        /// </summary>
        /// <returns>a CompanyRepository</returns>
        public IRepository<Company> GetCompanyRepository()
        {
            return new CompanyRepository();
        }
    }
}

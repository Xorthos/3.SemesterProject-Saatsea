using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repositories.Abstraction;

namespace Context.Repositories.Abstraction
{
    public interface ICompanyRepository : IRepository<Company>
    {
        bool AuthenticateCompany(string userName, string password);

        Company Get(string email);
    }
}

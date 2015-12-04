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
    class LogMOCK : ServiceGateway<Log>
    {
        public override Log Add(Log item)
        {
            MOCKData.logs.Add(item);
            return item;
        }

        public override IEnumerable<Log> GetAll()
        {
            return MOCKData.logs;
        }

        public override Log Get(int id)
        {
            return MOCKData.logs.FirstOrDefault(log => log.ID == id);
        }

        public override bool Update(Log item)
        {
            Log log = MOCKData.logs.FirstOrDefault(lo => lo.ID == item.ID);
            log.Employees = item.Employees;
            log.Company = item.Company;
            log.Date = item.Date;
            log.Import = item.Import;
            return true;
        }

        public LogMOCK(LoggedInModel model) : base(model)
        {
        }
    }
}

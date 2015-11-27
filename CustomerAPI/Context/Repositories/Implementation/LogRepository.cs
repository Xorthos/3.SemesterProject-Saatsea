using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repositories.Abstraction;
using static DAL.Context.Context;

namespace DAL.Repositories.Implementation
{
    class LogRepository : IRepository<Log>
    {
        public Log Add(Log item)
        {
            using (var ctx = new DAL.Context.Context())
            {
                foreach (var empl in item.Employees)
                {
                    ctx.Employees.Attach(empl);
                }

                var result = ctx.Logs.Add(item);
                return result;
            }
        }

        public IEnumerable<Log> GetAll()
        {
            using (var ctx = new DAL.Context.Context())
            {
                return ctx.Logs.Include("Employee").ToList();
            }
        }

        public Log Get(int id)
        {
            using (var ctx = new DAL.Context.Context())
            {
                return ctx.Logs.Where(c => c.ID == id).FirstOrDefault();
            }
        }

        public bool Update(Log item)
        {
            using (var ctx = new DAL.Context.Context())
            {
                var result = ctx.Entry(item).Entity;

                if (result == null)
                    return false;

                result.Employees = item.Employees;
                result.CompanyID = item.CompanyID;
                result.Date = item.Date;
                result.Import = item.Import;

                ctx.SaveChanges();
                return true;
            }
        }

        public bool DeActivate(Log item)
        {
            using (var ctx = new DAL.Context.Context())
            {
                var result = ctx.Entry(item).Entity;

                if (result == null)
                    return false;

                ctx.SaveChanges();
                return true;
            }
        }
    }
}

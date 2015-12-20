using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repositories.Abstraction;
using DAL.Context;

namespace DAL.Repositories.Implementation
{
   public class LogRepository : IRepository<Log>
    {
        public Log Add(Log item)
        {
            using (var ctx = new Context.Context())
            {
                if (item.Employees != null)
                {
                    foreach (var empl in item.Employees)
                    {
                        ctx.Employees.Attach(empl);
                        //ctx.Entry(empl.Company).State = EntityState.Detached;
                    }
                }
                if (item.Company != null)
                {
                    ctx.Users.Attach(item.Company.Identity);
                    ctx.Companies.Attach(item.Company);
                }

                var result = ctx.Logs.Add(item);
                ctx.SaveChanges();
                return result;
            }
        }

        public IEnumerable<Log> GetAll()
        {
            using (var ctx = new Context.Context())
            {
                return ctx.Logs.Include("Employees").Include(c => c.Company.Identity).OrderByDescending(c=> c.Date).ToList();
            }
        }

        public Log Get(int id)
        {
            using (var ctx = new Context.Context())
            {

                return ctx.Logs.Include(c => c.Company.Identity).Include("Employees").FirstOrDefault(c => c.Id == id && c.Active);
            }
        }

        public bool Update(Log item)
        {
            using (var ctx = new Context.Context())
            {
                var result = ctx.Entry(item).Entity;

                if (result == null)
                    return false;

                result.Employees = item.Employees;
                result.Company = item.Company;
                result.Date = item.Date;
                result.Import = item.Import;

                ctx.SaveChanges();
                return true;
            }
        }

        public bool ChangeState(Log item)
        {
            using (var ctx = new Context.Context())
            {
                var result = ctx.Entry(item).Entity;

                if (result == null)
                    return false;

                result.Active = false;
                ctx.SaveChanges();
                return true;
            }
        }
    }
}

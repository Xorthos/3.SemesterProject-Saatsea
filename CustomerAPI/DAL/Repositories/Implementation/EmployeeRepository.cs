using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repositories.Abstraction;
using DAL.Context;

namespace DAL.Repositories.Implementation
{
   public class EmployeeRepository : IRepository<Employee>
    {
        /// <summary>
        /// Adds an employee to the database
        /// </summary>
        /// <param name="item">the item to add</param>
        /// <returns>the item with the right primary key</returns>
        public Employee Add(Employee item)
        {
            using (var ctx = new Context.Context())
            {

                ctx.Companies.Attach(item.Company);

                var result = ctx.Employees.Add(item);
                ctx.SaveChanges();
                return result;
            }
        }

        /// <summary>
        /// Gets all the employees from the database
        /// </summary>
        /// <returns>an list of employees</returns>
        public IEnumerable<Employee> GetAll()
        {
            using (var ctx = new Context.Context())
            {
                return ctx.Employees.Include("Logs").ToList();
            }
        }

        /// <summary>
        /// gets a specific employee
        /// </summary>
        /// <param name="id">the id of the wanted employee</param>
        /// <returns>returns the wanted employee</returns>
        public Employee Get(int id)
        {
            using (var ctx = new Context.Context())
            {
                return ctx.Employees.Include("Logs").FirstOrDefault(c => c.Id == id && c.Active);
            }
        }

        /// <summary>
        /// Updates the item
        /// </summary>
        /// <param name="item">The item to be updated</param>
        /// <returns>true if it was successfully updated</returns>
        public bool Update(Employee item)
        {
            using (var ctx = new Context.Context())
            {
                var result = ctx.Entry(item).Entity;

                if (result == null)
                    return false;

                result.Logs = item.Logs;
                result.Company = item.Company;
                result.FirstName = item.FirstName;

                ctx.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Deactivates the given item
        /// </summary>
        /// <param name="item">the item to be deactivated</param>
        /// <returns>true if it was successfully deactivated</returns>
        public bool ChangeState(Employee item)
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

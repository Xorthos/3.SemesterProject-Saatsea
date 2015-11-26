using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context.Models;
using Context.Repositories.Abstraction;
using Context = DAL.Context.Context;

namespace DAL.Context.Repositories.Implementation
{
    public class CompanyRepository : IRepository<Company>
    {
        /// <summary>
        /// Add an item, to the database
        /// </summary>
        /// <param name="item">The item to be added</param>
        /// <returns>The same company but now with a primary key.</returns>
        public Company Add(Company item)
        {
            using (var ctx = new DAL.Context.Context())
            {
                foreach (var empl in item.Employees)
                {
                    ctx.Employees.Attach(empl);
                }

                var result = ctx.Companies.Add(item);
                ctx.SaveChanges();

                return result;
            }
        }

        /// <summary>
        /// Gets all the companies from the database
        /// </summary>
        /// <returns>a list containing all the companies</returns>
        public IEnumerable<Company> GetAll()
        {
            using (var ctx = new DAL.Context.Context())
            {
                IEnumerable<Company> result = ctx.Companies.Include("Employee").ToList();
                return result;
            }
        }

        /// <summary>
        /// Returns a specific company, with a given id.
        /// </summary>
        /// <param name="id">the id of a company</param>
        /// <returns>the company with the id</returns>
        public Company Get(int id)
        {
            using (var ctx = new DAL.Context.Context())
            {
                var result = ctx.Companies.Where(c=> c.ID == id).Include("Employee").FirstOrDefault();
                return result;
            }
        }

        /// <summary>
        /// Updates an item in the database
        /// </summary>
        /// <param name="item">the company that will be updated</param>
        /// <returns>true if it succeds</returns>
        public bool Update(Company item)
        {
            using (var ctx = new Context())
            {
                Company result = ctx.Entry(item).Entity;

                if (result == null)
                {
                    return false;
                }

                //sets the information
                result.Employees = item.Employees;
                result.Email = item.Email;
                result.Name = item.Name;
                result.PhoneNr = item.PhoneNr;
                result.Zipcode = item.Zipcode;
                return true;
            }
        }

        public bool DeActivate(Company item)
        {
            throw new NotImplementedException();
        }
    }
}

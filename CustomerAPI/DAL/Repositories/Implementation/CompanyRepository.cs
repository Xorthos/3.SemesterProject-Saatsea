using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context.Models;
using Context.Repositories.Abstraction;
using DAL.Models;
using DAL.Repositories.Abstraction;
using DAL.Context;
using DAL.Repositories.Implementation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Context.Repositories.Implementation
{
    public class CompanyRepository : ICompanyRepository
    {
        /// <summary>
        /// Add an item, to the database
        /// </summary>
        /// <param name="item">The item to be added</param>
        /// <returns>The same company but now with a primary key.</returns>
        public Company Add(Company item)
        {
            using (var ctx = new Context())
            {
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
            using (var ctx = new Context())
            {
              
                //var result=ctx.Companies.Where(c=> c.Active).Include("Employees").ToList();
                var result = ctx.Companies.Include("Employees").Include("Identity").ToList();
               
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
            using (var ctx = new Context())
            {
                return ctx.Companies.Include("Employees").Include("Identity").FirstOrDefault(c => c.Id == id);
            }
        }

        /// <summary>
        /// Returns a specific company, with a given email.
        /// </summary>
        /// <param name="email">the email of a company</param>
        /// <returns>the company with the email</returns>
        public Company Get(string email)
        {
            using (var ctx = new Context())
            {
                return ctx.Companies.Include("Employees").FirstOrDefault(c => c.Identity.Email.Equals(email));
            }
        }

        /// <summary>
        /// Updates an item in the database
        /// </summary>
        /// <param name="item">the company that will be updated</param>
        /// <returns>true if it succeds</returns>
        public bool Update(Company item)
        {
            try
            {
                using (var ctx = new Context())
                {
                    Company result = ctx.Entry(item).Entity;
                   
                    if (result == null)
                    {
                        return false;
                    }
                    
                    foreach (var empsToAttach in item.Employees)
                    {
                        ctx.Employees.Attach(empsToAttach);
                    }

                    //sets the information
                    result.Employees = item.Employees;
                    result.Name = item.Name;
                    result.PhoneNr = item.PhoneNr;

                    ctx.Entry(result).State = EntityState.Modified;

                    ctx.SaveChanges();
                    return true;
                }
            }
            catch(Exception e) {
                return false;
            }
        }

        /// <summary>
        /// will deactivate an item
        /// </summary>
        /// <param name="item">the item to be deactivated</param>
        /// <returns>true if the item was successfully deactivated</returns>
        public bool ChangeState(Company item)
        {
            using (var ctx = new Context())
            {
                var result = ctx.Entry(item).Entity;
                if (result == null)
                {
                    return false;
                }
                if (result.Active) { 
                result.Active = false;
                }
                else {
                    result.Active = true;
                }

                ctx.Entry(result).State = EntityState.Modified;
                
                ctx.SaveChanges();
              
                return true;
            }
        }

        //checks the recieved username and password against the database to see if the identity is present and if the password mathces.
        public bool AuthenticateCompany(string userName, string password)
        {
            var ctx = new Context();
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));
            
            if (um.CheckPassword(um.FindByEmail(userName), password))
            {
                return true;
            }
            
            return false;
        }
    }
}

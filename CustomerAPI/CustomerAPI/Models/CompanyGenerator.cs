using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Context.Models;
using DAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CustomerAPI.Models
{
    public class CompanyGenerator
    {

        /// <summary>
        /// This will generate a new company from a view company
        /// </summary>
        /// <param name="comp">the company to be generated</param>
        /// <returns>the company that should be added to the database</returns>
        public Company GenerateCompany(ViewCompany comp, int _lenghtOfPassword, int _numberOfAlphabeticCharacters)
        {

            var result = new Company() {Active = true, Name = comp.Name, PhoneNr = comp.PhoneNr};

            //Generates a random password, and makes a new user with the correct email
            var password = System.Web.Security.Membership.GeneratePassword(_lenghtOfPassword, _numberOfAlphabeticCharacters);
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DAL.Context.Context()));
            var user = new ApplicationUser()
            {
                UserName = comp.Email,
                Email = comp.Email
            };

            um.Create(user, password);
            //Generates the access string by encoding the email and the password into an array of bytes.
            var bytes = System.Text.Encoding.UTF8.GetBytes(comp.Email + ":" + password);
            result.AccessString = System.Convert.ToBase64String(bytes);
            result.Active = true;

            //This will be so that the database will make the relation between the two.
            var item = um.FindByEmail(comp.Email);
            result.IdentityId = item.Id;

            return result;
        }

        /// <summary>
        /// This will parse a company to a view company
        /// </summary>
        /// <param name="company">The company to be converted</param>
        /// <returns>A view company corresponding to the given company</returns>
        public ViewCompany ParseCompany(Company company)
        {
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DAL.Context.Context()));
            var user = um.FindById(company.IdentityId);

            //We are working with seeded data, which we cannot give an Identity, therefore we add in this small hack.
            if (user == null)
                return new ViewCompany() { AccessString = company.AccessString, Active = company.Active, Email = "hackemail@emails.com", Employees = company.Employees, PhoneNr = company.PhoneNr, Id = company.Id, Name = company.Name };
            else
                return new ViewCompany() {AccessString = company.AccessString, Active = company.Active, Email = user.Email, Employees = company.Employees, PhoneNr = company.PhoneNr, Id = company.Id, Name = company.Name};
        }

        /// <summary>
        /// this will parse a range of companies
        /// </summary>
        /// <returns>an Ienumerable of view companies</returns>
        public IEnumerable<ViewCompany> ParseCompanyRange(IEnumerable<Company> companies)
        {
            var result = new List<ViewCompany>();

            foreach (var item in companies)
            {
                result.Add(ParseCompany(item));
            }
            return result;
        } 

        /// <summary>
        /// This will parse a viewcompany to a company
        /// </summary>
        /// <param name="company">the viewcompany to be converted</param>
        /// <returns>a company corresponding to the given viewcompany</returns>
        public Company ParseViewCompany(ViewCompany company)
        {
            var um = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new DAL.Context.Context()));
            return new Company() { Active = company.Active, Name = company.Name, PhoneNr = company.PhoneNr, AccessString = company.AccessString, Employees = company.Employees, Identity = um.FindByEmail(company.Email) };
        }
    }
}
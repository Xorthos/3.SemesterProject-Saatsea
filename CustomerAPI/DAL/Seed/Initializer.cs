﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Context.Models;
using DAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Seed
{
    public class Initializer : DropCreateDatabaseAlways<Context.Context>
    {
        
        public Initializer()
        {
            //This should make the database initialise
            var cont = new Context.Context();
            //cont.Database.Initialize(true);
            cont.Database.Delete(); // the proper initializing doesn't work, so we use this.
            Context.Context context = new Context.Context();

            
            InitializeDatabase(context);
            Seed(context);
            MakeRelation();
        }

        /// <summary>
        /// Makes a relation between the company and the Identity
        /// </summary>
        private void MakeRelation()
        {
            using (var ctx = new DAL.Context.Context())
            {
                UserManager<IdentityUser> um = new UserManager<IdentityUser>(new UserStore<IdentityUser>(ctx));
                var user = um.FindByEmail("random@hej.com");
                var company = ctx.Companies.FirstOrDefault(c => c.Name.Equals("Random"));
                company.Identity = user;

                var user2 = um.FindByEmail("douche@hej.com");
                var company2 = ctx.Companies.FirstOrDefault(c => c.Name.Equals("Douche"));
                company2.Identity = user2;

                var user3 = um.FindByEmail("sup@hej.com");
                var company3 = ctx.Companies.FirstOrDefault(c => c.Name.Equals("Sup"));
                company3.Identity = user3;

                var user4 = um.FindByEmail("house@hej.com");
                var company4 = ctx.Companies.FirstOrDefault(c => c.Name.Equals("House"));
                company4.Identity = user4;
                ctx.SaveChanges();
            }
        }

        public static void Initalize()
        {
            Database.SetInitializer(new Initializer());
        }

        public override void InitializeDatabase(DAL.Context.Context context)
        {
            Company comp1 = new Company() { Id = 1, Name = "Random", PhoneNr = "23541365", Active =true};
            Company comp2 = new Company() { Id = 2, Name = "Douche", PhoneNr = "67352543", Active = true };
            Company comp3 = new Company() { Id = 3, Name = "Sup", PhoneNr = "85354256", Active = true };
            Company comp4 = new Company() { Id = 4, Name = "House", PhoneNr = "56123465", Active = true};

            Employee emp1 = context.Employees.Add(new Employee() { Company = comp1, Id = 1, FirstName = "Hans", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "Højvej 22", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", Phone = "56428657", Active = true, Rank = "Programmer" });
            Employee emp2 = context.Employees.Add(new Employee() { Company = comp1, Id = 1, FirstName = "Grete", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "esbjerg vej 53", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", Phone = "45732137", Active = true, Rank = "Cisco god" });
            Employee emp3 = context.Employees.Add(new Employee() { Company = comp1, Id = 1, FirstName = "Bente", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "skrænten 123", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", Phone = "45843255", Active = true, Rank = "Media guy" });
            Employee emp4 = context.Employees.Add(new Employee() { Company = comp1, Id = 1, FirstName = "Jens", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "random vej 54", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", Phone = "55478965", Active = true, Rank = "Programmer" });
            Employee emp5 = context.Employees.Add(new Employee() { Company = comp1, Id = 1, FirstName = "Jørgen", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "skolevej 35", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", Phone = "31245678", Active = true, Rank = "Programmer" });
            Employee emp6 = context.Employees.Add(new Employee() { Company = comp2, Id = 1, FirstName = "Lars", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "kongensgade 87", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", Phone = "73124567", Active = true, Rank = "Media guy" });
            Employee emp7 = context.Employees.Add(new Employee() { Company = comp2, Id = 1, FirstName = "Henrik", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "hærvej 282", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", Phone = "41212323", Active = true, Rank = "Programmer" });
            Employee emp8 = context.Employees.Add(new Employee() { Company = comp2, Id = 1, FirstName = "Lasse", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "nizzle vej 21", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", Phone = "78431215", Active = true, Rank = "Media guy" });
            Employee emp9 = context.Employees.Add(new Employee() { Company = comp2, Id = 1, FirstName = "James", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "Højvej 22", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", Phone = "11121232", Active = true, Rank = "Programmer" });
            Employee emp10 = context.Employees.Add(new Employee() { Company = comp2, Id = 1, FirstName = "Lise", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "Højvej 22", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", Phone = "45631321", Active = true, Rank = "Media guy" });
            Employee emp11 = context.Employees.Add(new Employee() { Company = comp3, Id = 1, FirstName = "Ært", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "Højvej 22", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", Phone = "21235423", Active = true, Rank = "Programmer" });
            Employee emp12 = context.Employees.Add(new Employee() { Company = comp3, Id = 1, FirstName = "Martin", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "Højvej 22", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", Phone = "23656985", Active = true, Rank = "Media guy" });
            Employee emp13 = context.Employees.Add(new Employee() { Company = comp3, Id = 1, FirstName = "Lone", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "Højvej 22", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", Phone = "23656987", Active = true, Rank = "Programmer" });
            Employee emp14 = context.Employees.Add(new Employee() { Company = comp3, Id = 1, FirstName = "Kasper", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "Højvej 22", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", Phone = "98968654", Active = true, Rank = "Media guy" });
            Employee emp15 = context.Employees.Add(new Employee() { Company = comp3, Id = 1, FirstName = "Ole", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "Højvej 22", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", Phone = "78945456", Active = true, Rank = "Media guy" });
            Employee emp16 = context.Employees.Add(new Employee() { Company = comp3, Id = 1, FirstName = "Anne", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "Højvej 22", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", Phone = "46546546", Active = true, Rank = "Media guy" });


            comp1.Employees = new List<Employee>() { emp1, emp2, emp3, emp4, emp5 };
            comp2.Employees = new List<Employee>() { emp6, emp7, emp8, emp9, emp10 };
            comp3.Employees = new List<Employee>() { emp11, emp12, emp13, emp14, emp15, emp16 };
            comp4.Employees = new List<Employee>();

            context.Companies.Add(comp1);
            context.Companies.Add(comp2);
            context.Companies.Add(comp3);
            context.Companies.Add(comp4);

            List<Employee> empList1 = new List<Employee>() { emp1, emp2, emp3 };
            List<Employee> empList2 = new List<Employee>() { emp6, emp7, emp8, emp9, emp10 };
            List<Employee> empList3 = new List<Employee>() { emp11, emp12, emp13 };
            List<Employee> empList4 = new List<Employee>() { emp14, emp15 };
            List<Employee> empList5 = new List<Employee>() { emp4, emp5 };
            List<Employee> empList7 = new List<Employee>() { emp1, emp2, emp3, emp4, emp5 };
            List<Employee> empList8 = new List<Employee>() { emp16 };

            context.Logs.Add(new Log() { Company = comp1, Employees = empList1, Date = DateTime.Now.AddDays(-1), Id = 1, Import = true, Active=true});
            context.Logs.Add(new Log() { Company = comp2, Employees = empList2, Date = DateTime.Now, Id = 2, Import = true, Active = true });
            context.Logs.Add(new Log() { Company = comp3, Employees = empList3, Date = DateTime.Now.AddDays(-14), Id = 3, Import = true, Active = true });
            context.Logs.Add(new Log() { Company = comp3, Employees = empList4, Date = DateTime.Now, Id = 4, Import = true, Active = true });
            context.Logs.Add(new Log() { Company = comp1, Employees = empList5, Date = DateTime.Now, Id = 5, Import = true, Active = true });
            context.Logs.Add(new Log() { Company = comp1, Employees = empList7, Date = DateTime.Now.AddDays(5), Id = 7, Import = false, Active = true });
            context.Logs.Add(new Log() { Company = comp3, Employees = empList8, Date = DateTime.Now.AddDays(3), Id = 8, Import = true, Active = true });

            
            base.InitializeDatabase(context);
            

        }

        protected override void Seed(Context.Context context)
        {
                var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                rm.Create(new IdentityRole("Admin"));
                rm.Create(new IdentityRole("Company"));
                var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var user = new ApplicationUser()
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com"
                };
                um.Create(user, "_admin123");

                var newUser = um.FindByName("admin@admin.com");

                um.AddToRole(newUser.Id, "Admin");

                var compUser = new ApplicationUser()
                {
                    UserName = "random@hej.com",
                    Email = "random@hej.com"
                };
                um.Create(compUser, "randompass");
            
            compUser = new ApplicationUser()
            {
                UserName = "house@hej.com",
                Email = "house@hej.com"
            };
            um.Create(compUser, "housepass");

            newUser = um.FindByName("house@hej.com");

            um.AddToRole(newUser.Id, "Company");
            
                newUser = um.FindByName("random@hej.com");

                um.AddToRole(newUser.Id, "Company");

            compUser = new ApplicationUser()
            {
                UserName = "sup@hej.com",
                Email = "sup@hej.com"
            };
            um.Create(compUser, "suppass");

            newUser = um.FindByName("sup@hej.com");

            um.AddToRole(newUser.Id, "Company");

            compUser = new ApplicationUser()
            {
                UserName = "douche@hej.com",
                Email = "douche@hej.com"
            };
            um.Create(compUser, "douchepass");

            newUser = um.FindByName("douche@hej.com");

            um.AddToRole(newUser.Id, "Company");

            base.Seed(context);
        }
    }
}

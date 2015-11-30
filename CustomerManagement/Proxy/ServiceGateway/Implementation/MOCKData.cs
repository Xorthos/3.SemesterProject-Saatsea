using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxy.Models;

namespace Proxy.ServiceGateway.Implementation
{
    public class MOCKData
    {
        public static List<Company> companies = new List<Company>();
        public static List<Employee> employees = new List<Employee>();
        public static List<Log> logs = new List<Log>();

        public static void InitMOCKData()
        {
            Company comp1 = new Company() {Email = "random@hej.com", ID = 1, Name = "Random", PhoneNr = "23541365", Zipcode = 2354};
            Company comp2 = new Company() { Email = "douche@hej.com", ID = 2, Name = "douche", PhoneNr = "67352543", Zipcode = 1323 };
            Company comp3 = new Company() { Email = "supster@hej.com", ID = 3, Name = "Sup", PhoneNr = "85354256", Zipcode = 5231 };

            Employee emp1 = new Employee() {Company = comp1, Id = 1, FirstName = "Hans", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "Højvej 22", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", CprNumber = "5730284495", Phone = "56428657", Active = true, Rank = "Programmer"};
            Employee emp2 = new Employee() { Company = comp1, Id = 1, FirstName = "Grete", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "esbjerg vej 53", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", CprNumber = "2679166064", Phone = "45732137", Active = true, Rank = "Cisco god" };
            Employee emp3 = new Employee() { Company = comp1, Id = 1, FirstName = "Bente", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "skrænten 123", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", CprNumber = "5296636916", Phone = "45843255", Active = true, Rank = "Media guy" };
            Employee emp4 = new Employee() { Company = comp1, Id = 1, FirstName = "Jens", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "random vej 54", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", CprNumber = "4651134865", Phone = "55478965", Active = true, Rank = "Programmer" };
            Employee emp5 = new Employee() { Company = comp1, Id = 1, FirstName = "Jørgen", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "skolevej 35", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", CprNumber = "8641325846", Phone = "31245678", Active = true, Rank = "Programmer" };
            Employee emp6 = new Employee() { Company = comp2, Id = 1, FirstName = "Lars", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "kongensgade 87", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", CprNumber = "7654321685", Phone = "73124567", Active = true, Rank = "Media guy" };
            Employee emp7 = new Employee() { Company = comp2, Id = 1, FirstName = "Henrik", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "hærvej 282", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", CprNumber = "4865858576", Phone = "41212323", Active = true, Rank = "Programmer" };
            Employee emp8 = new Employee() { Company = comp2, Id = 1, FirstName = "Lasse", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "nizzle vej 21", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", CprNumber = "1351325642", Phone = "78431215", Active = true, Rank = "Media guy" };
            Employee emp9 = new Employee() { Company = comp2, Id = 1, FirstName = "James", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "Højvej 22", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", CprNumber = "7946581325", Phone = "11121232", Active = true, Rank = "Programmer" };
            Employee emp10 = new Employee() { Company = comp2, Id = 1, FirstName = "Lise", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "Højvej 22", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", CprNumber = "7954613524", Phone = "45631321", Active = true, Rank = "Media guy" };
            Employee emp11 = new Employee() { Company = comp3, Id = 1, FirstName = "Ært", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "Højvej 22", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", CprNumber = "6582163476", Phone = "21235423", Active = true, Rank = "Programmer" };
            Employee emp12 = new Employee() { Company = comp3, Id = 1, FirstName = "Martin", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "Højvej 22", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", CprNumber = "4651358646", Phone = "23656985", Active = true, Rank = "Media guy" };
            Employee emp13 = new Employee() { Company = comp3, Id = 1, FirstName = "Lone", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "Højvej 22", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", CprNumber = "1358462156", Phone = "23656987", Active = true, Rank = "Programmer" };
            Employee emp14 = new Employee() { Company = comp3, Id = 1, FirstName = "Kasper", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "Højvej 22", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", CprNumber = "7987987564", Phone = "98968654", Active = true, Rank = "Media guy" };
            Employee emp15 = new Employee() { Company = comp3, Id = 1, FirstName = "Ole", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "Højvej 22", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", CprNumber = "3216548523", Phone = "78945456", Active = true, Rank = "Media guy" };
            Employee emp16 = new Employee() { Company = comp3, Id = 1, FirstName = "Anne", LastName = "Peterson", BirthDate = DateTime.Now.AddYears(-36), Address = "Højvej 22", ZipCode = 6700, City = "Esbjerg", Country = "Danmark", CprNumber = "1256745896", Phone = "46546546", Active = true, Rank = "Media guy" };
            employees = new List<Employee>() { emp1, emp2, emp3, emp4, emp5, emp6, emp7, emp8, emp9, emp10, emp11, emp12, emp13, emp14, emp15, emp16};

            
            comp1.Employees = new List<Employee>() {emp1, emp2, emp3, emp4, emp5};
            comp2.Employees = new List<Employee>() { emp6, emp7, emp8, emp9, emp10 };
            comp3.Employees = new List<Employee>() { emp11, emp12, emp13, emp14, emp15, emp16 };
            companies = new List<Company>() {comp1, comp2, comp3};

            List<Employee> empList1 = new List<Employee>() { emp1, emp2, emp3 };
            List<Employee> empList2 = new List<Employee>() { emp6, emp7, emp8, emp9, emp10 };
            List<Employee> empList3 = new List<Employee>() { emp11, emp12, emp13 };
            List<Employee> empList4 = new List<Employee>() { emp14, emp15 };
            List<Employee> empList5 = new List<Employee>() { emp4, emp5 };
            List<Employee> empList6 = new List<Employee>() { emp6, emp7, emp8, emp9, emp10 };
            List<Employee> empList7 = new List<Employee>() { emp1, emp2, emp3, emp4, emp5 };
            List<Employee> empList8 = new List<Employee>() { emp16 };


            Log log1 = new Log() { Company = comp1, Employees = empList1, Date = DateTime.Now, ID = 1, Import = true };
            Log log2 = new Log() { Company = comp2, Employees = empList2, Date = DateTime.Now, ID = 2, Import = true };
            Log log3 = new Log() { Company = comp3, Employees = empList3, Date = DateTime.Now, ID = 3, Import = true };
            Log log4 = new Log() { Company = comp3, Employees = empList4, Date = DateTime.Now, ID = 4, Import = true };
            Log log5 = new Log() { Company = comp1, Employees = empList5, Date = DateTime.Now, ID = 5, Import = true };
            Log log6 = new Log() { Company = comp2, Employees = empList6, Date = DateTime.Now, ID = 6, Import = false };
            Log log7 = new Log() { Company = comp1, Employees = empList7, Date = DateTime.Now, ID = 7, Import = false };
            Log log8 = new Log() { Company = comp3, Employees = empList8, Date = DateTime.Now, ID = 8, Import = true };
            logs = new List<Log>() {log1, log2, log3, log4, log5, log6, log7, log8};

        }
    }
}

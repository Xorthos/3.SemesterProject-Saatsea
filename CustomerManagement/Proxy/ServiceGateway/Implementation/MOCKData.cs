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

            Employee emp1 = new Employee() {Company = comp1, ID = 1, Name = "Hans"};
            Employee emp2 = new Employee() { Company = comp1, ID = 1, Name = "Grete" };
            Employee emp3 = new Employee() { Company = comp1, ID = 1, Name = "Bente" };
            Employee emp4 = new Employee() { Company = comp1, ID = 1, Name = "Jens" };
            Employee emp5 = new Employee() { Company = comp1, ID = 1, Name = "Jørgen" };
            Employee emp6 = new Employee() { Company = comp2, ID = 1, Name = "Lars" };
            Employee emp7 = new Employee() { Company = comp2, ID = 1, Name = "Henrik" };
            Employee emp8 = new Employee() { Company = comp2, ID = 1, Name = "Lasse" };
            Employee emp9 = new Employee() { Company = comp2, ID = 1, Name = "James" };
            Employee emp10 = new Employee() { Company = comp2, ID = 1, Name = "Lise" };
            Employee emp11 = new Employee() { Company = comp3, ID = 1, Name = "Ært" };
            Employee emp12 = new Employee() { Company = comp3, ID = 1, Name = "Martin" };
            Employee emp13 = new Employee() { Company = comp3, ID = 1, Name = "Lone" };
            Employee emp14 = new Employee() { Company = comp3, ID = 1, Name = "Kasper" };
            Employee emp15 = new Employee() { Company = comp3, ID = 1, Name = "Ole" };
            Employee emp16 = new Employee() { Company = comp3, ID = 1, Name = "Anne" };
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

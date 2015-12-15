using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using DAL.Facade.Implementation;
using DAL.Models;

namespace CustomerAPI.BLL
{
    public class ImportExportLogic
    {
        public bool Import(IEnumerable<Employee> Employees )
        {
            Facade facade = new Facade();

            if (Employees == null || !Employees.Any())
            {
                return false;
            }


            Company comp = facade.GetCompanyRepository().Get(Thread.CurrentPrincipal.Identity.Name);
            Log newLog = new Log() { Company = comp, Active = true, Date = DateTime.Now, Import = true, Employees = new List<Employee>() };

            //Runs through every employee from the import list and checks if they are already present in the system.
            bool changesWereMade = false;
            foreach (var emp in Employees)
            {
                //Checks if the employee is already in the system.
                if (!ContainsEmployee(comp, emp))
                {
                    //If it is not in the system the nessecary changes will be made.
                    changesWereMade = true;
                    emp.Company = comp;
                    Employee newEmp = facade.GetEmployeeRepository().Add(emp);
                    comp.Employees.Add(newEmp);
                    newLog.Employees.Add(newEmp);
                }

            }

            //If changes were made the company will be updated and the new log will be saved. Otherwise it will be discarded.
            if (changesWereMade)
            {
                facade.GetCompanyRepository().Update(comp);
                facade.GetLogRepository().Add(newLog);
            }

            return true;
        }

        public List<Employee> Export()
        {
            Facade facade = new Facade();
            Company comp = facade.GetCompanyRepository().Get(Thread.CurrentPrincipal.Identity.Name);
            Log newLog = new Log() { Company = comp, Active = true, Date = DateTime.Now, Import = false, Employees = comp.Employees };
            facade.GetLogRepository().Add(newLog);
            return comp.Employees;
        }

        //Checks wether the recieved employee is already within the company list of employees.
        private bool ContainsEmployee(Company comp, Employee emp)
        {
            bool contains = false;

            contains = comp.Employees.FirstOrDefault(c => c.Address.Equals(emp.Address) && c.BirthDate.Year == emp.BirthDate.Year && c.BirthDate.Month == emp.BirthDate.Month && c.BirthDate.Day == emp.BirthDate.Day && c.FirstName.Equals(emp.FirstName)
            && c.LastName.Equals(emp.LastName) && c.Phone.Equals(emp.Phone)) != null;

            return contains;
        }
    }
}
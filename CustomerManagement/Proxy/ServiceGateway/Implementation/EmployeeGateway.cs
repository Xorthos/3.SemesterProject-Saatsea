using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxy.Models;
using Proxy.ServiceGateway.Abstraction;

namespace Proxy.ServiceGateway.Implementation
{
    public class EmployeeGateway : ServiceGateway<Employee>
    {
        //Constant, the address of the web api
        protected static readonly string EMPLOYEE_END_POINT = END_POINT + "Employee/";

        public override Employee Add(Employee item)
        {
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.PostAsJsonAsync(EMPLOYEE_END_POINT, item).Result;

                return JsonConvert.DeserializeObject<Employee>(result.Content.ReadAsStringAsync().Result);
            }
        }

        public override IEnumerable<Employee> GetAll()
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(EMPLOYEE_END_POINT).Result;

                return JsonConvert.DeserializeObject<List<Employee>>(response.Content.ReadAsStringAsync().Result);
            }
        }

        public override Employee Get(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(EMPLOYEE_END_POINT + id).Result;

                return JsonConvert.DeserializeObject<Employee>(response.Content.ReadAsStringAsync().Result);
            }
        }

        public override bool Update(Employee item)
        {
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.PutAsJsonAsync(EMPLOYEE_END_POINT, item).Result;

                return JsonConvert.DeserializeObject<bool>(result.Content.ReadAsStringAsync().Result);
            }
        }
    }
}

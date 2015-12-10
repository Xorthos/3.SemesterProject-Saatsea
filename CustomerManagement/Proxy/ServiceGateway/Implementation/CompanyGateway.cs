using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxy.Authorization;
using Proxy.Models;
using Proxy.Models.AuthorizationModels;
using Proxy.ServiceGateway.Abstraction;

namespace Proxy.ServiceGateway.Implementation
{
    class CompanyGateway : ServiceGateway<Company>
    {
        //Constant, the address of the web api
        protected static readonly string COMPANY_END_POINT = END_POINT + "Company/";

        public CompanyGateway(LoggedInModel model) : base(model)
        {
        }

        public override Company Add(Company item)
        {
            using (var httpClient = AuthorizeHttpClient.GetAuthorizeClient(_loggedInModel))
            {
                var result = httpClient.PostAsJsonAsync(COMPANY_END_POINT, item).Result;

                return JsonConvert.DeserializeObject<Company>(result.Content.ReadAsStringAsync().Result);
            }
        }

        public override IEnumerable<Company> GetAll()
        {
            using (var httpClient = AuthorizeHttpClient.GetAuthorizeClient(_loggedInModel))
            {
                var response = httpClient.GetAsync(COMPANY_END_POINT).Result;

                return JsonConvert.DeserializeObject<List<Company>>(response.Content.ReadAsStringAsync().Result);
            }
        }

        public override Company Get(int id)
        {
            using (var httpClient = AuthorizeHttpClient.GetAuthorizeClient(_loggedInModel))
            {
                var response = httpClient.GetAsync(COMPANY_END_POINT + id).Result;

                return JsonConvert.DeserializeObject<Company>(response.Content.ReadAsStringAsync().Result);
            }
        }

        public override bool Update(Company item)
        {
            using (var httpClient = AuthorizeHttpClient.GetAuthorizeClient(_loggedInModel))
            {
                var result = httpClient.PutAsJsonAsync(COMPANY_END_POINT, item).Result;

                return JsonConvert.DeserializeObject<bool>(result.Content.ReadAsStringAsync().Result);
            }
        }



        public override bool ChangeState(int id)
        {
            using (var httpClient = AuthorizeHttpClient.GetAuthorizeClient(_loggedInModel))
            {
                var result = httpClient.PutAsJsonAsync(COMPANY_END_POINT + "/ChangeState", id).Result;

                return JsonConvert.DeserializeObject<bool>(result.Content.ReadAsStringAsync().Result);
            }
        }
    }
}

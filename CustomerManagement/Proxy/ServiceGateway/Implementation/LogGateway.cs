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
    class LogGateway : ServiceGateway<Log>
    {
        protected static readonly string LOG_END_POINT = END_POINT + "Log/";

        public override Log Add(Log item)
        {
            using (var httpClient = AuthorizeHttpClient.GetAuthorizeClient(_loggedInModel))
            {
                var result = httpClient.PostAsJsonAsync(LOG_END_POINT, item).Result;

                return JsonConvert.DeserializeObject<Log>(result.Content.ReadAsStringAsync().Result);
            }
        }

        public override IEnumerable<Log> GetAll()
        {
            using (var httpClient = AuthorizeHttpClient.GetAuthorizeClient(_loggedInModel))
            {
                var response = httpClient.GetAsync(LOG_END_POINT).Result;

                var result = JsonConvert.DeserializeObject<Log[]>(response.Content.ReadAsStringAsync().Result);
                return result.ToList();
            }
        }

        public override Log Get(int id)
        {
            using (var httpClient = AuthorizeHttpClient.GetAuthorizeClient(_loggedInModel))
            {
                var response = httpClient.GetAsync(LOG_END_POINT + id).Result;

                return JsonConvert.DeserializeObject<Log>(response.Content.ReadAsStringAsync().Result);
            }
        }

        public override bool Update(Log item)
        {
            using (var httpClient = AuthorizeHttpClient.GetAuthorizeClient(_loggedInModel))
            {
                var result = httpClient.PutAsJsonAsync(LOG_END_POINT, item).Result;

                return JsonConvert.DeserializeObject<bool>(result.Content.ReadAsStringAsync().Result);
            }
        }

        public override bool ChangeState(int id)
        {
            throw new NotImplementedException();
        }

        public LogGateway(LoggedInModel model) : base(model)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Proxy.Models;
using Proxy.Models.AuthorizationModels;

namespace Proxy.Authorization
{
    public class AuthorizeHttpClient
    {
        public static LoggedInModel Register(RegisterModel model)
        {
            using (var httpClient = new HttpClient())
            {
                var content = JsonConvert.SerializeObject(model);

                var request = new StringContent(content) {Headers = { ContentType = new MediaTypeWithQualityHeaderValue("application/json") } };
                var respond = httpClient.PostAsync(new Uri("http://localhost:2687/api/Account/Register"), request).Result;

                if (respond.StatusCode == HttpStatusCode.OK)
                    return Login(new LoginModel() {Email = model.Email, Password = model.Password});
                
                throw new Exception("Could not register");
                
            }
        }

        public static LoggedInModel Login(LoginModel model)
        {
            List<KeyValuePair<string, string>> content = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("Email", model.Email),
                new KeyValuePair<string, string>("Email", model.Password)
            };

            using (var httpClient = new HttpClient())
            {

                var respond = httpClient.PostAsync(new Uri("http://localhost:2687/Token"), new FormUrlEncodedContent(content) {Headers = { ContentType = new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded")}}).Result;
                dynamic result = JsonConvert.DeserializeObject<JObject>(respond.Content.ReadAsStringAsync().Result);
                
                if(respond.StatusCode == HttpStatusCode.OK)
                    return new LoggedInModel() {AuthenticationToken = result.access_token, Email = result.userName};

                throw new Exception("Could not log");
            }
        }
    }
}

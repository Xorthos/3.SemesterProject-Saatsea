using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Proxy.Models;
using Proxy.Models.AuthorizationModels;

namespace Proxy.Authorization
{
    public class AuthorizeHttpClient
    {
        /// <summary>
        /// This will send of a HttpClient, that will register the given model
        /// </summary>
        /// <param name="model">The values of the user to be registered</param>
        /// <returns>A logged in model which will contain a access_token, which should be stored</returns>
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

        /// <summary>
        /// This is sending of a http request, this will return a bearer token.
        /// </summary>
        /// <param name="model">Then model needed to log in</param>
        /// <returns>A logged in model containing, an access_token, which should be used to access stuff on the api</returns>
        public static LoggedInModel Login(LoginModel model)
        {
            List<KeyValuePair<string, string>> content = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("userName", model.Email),
                new KeyValuePair<string, string>("Password", model.Password)
            };

            using (var httpClient = new HttpClient())
            {
                var request = httpClient.PostAsync("http://localhost:2687/Token", new FormUrlEncodedContent(content)).Result;
                dynamic result = JObject.Parse(request.Content.ReadAsStringAsync().Result);

                if (request.StatusCode == HttpStatusCode.OK)
                    return new LoggedInModel() {AuthenticationToken = result.access_token, Email = result.userName};

                throw new Exception("Could not log");
            }
        }

        /// <summary>
        /// Returns a HttpClient, where the authorization header will be set, so that
        /// it can just be used, for sending and recieving things
        /// </summary>
        /// <param name="model">The information needed to access information on the api</param>
        /// <returns>An HttpClient with the authorization token already set.</returns>
        public static HttpClient GetAuthorizeClient(LoggedInModel model)
        {
            var result = new HttpClient();

            result.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", model.AuthenticationToken);

            return result;
        }
    }
}

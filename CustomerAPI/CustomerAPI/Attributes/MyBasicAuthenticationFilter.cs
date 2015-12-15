using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using Context.Models;
using DAL.Facade.Implementation;
using DAL.Models;

namespace CustomerAPI.Attributes
{
    public class MyBasicAuthenticationFilter : BasicAuthenticationFilter
    {

        public MyBasicAuthenticationFilter()
        { }

        public MyBasicAuthenticationFilter(bool active) : base(active)
        { }


        //Checks wether the username and password mathces.
        protected override bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
        {
            string uri = actionContext.Request.RequestUri.AbsolutePath;
            Facade facade = new Facade();

            if (facade.GetCompanyRepository().Get(username) == null ||
                     !facade.GetCompanyRepository().AuthenticateCompany(username, password))
            {
                if (uri.ToLower().Contains("import"))
                {
                    facade.GetLogRepository()
                        .Add(new Log() {Active = true, Date = DateTime.Now, Import = true, LogState = LogState.unknown});
                }
                else
                {
                    facade.GetLogRepository()
                        .Add(new Log() { Active = true, Date = DateTime.Now, Import = false, LogState = LogState.unknown });
                }
                return false;
            }

            else if (!facade.GetCompanyRepository().Get(username).Active)
            {
                if (uri.ToLower().Contains("import"))
                {
                    facade.GetLogRepository()
                        .Add(new Log()
                        {
                            Active = true,
                            Date = DateTime.Now,
                            Import = true,
                            LogState = LogState.unsuccessfull,
                            Company = facade.GetCompanyRepository().Get(username)
                        });
                }
                else
                {
                    facade.GetLogRepository()
                        .Add(new Log()
                        {
                            Active = true,
                            Date = DateTime.Now,
                            Import = false,
                            LogState = LogState.unsuccessfull,
                            Company = facade.GetCompanyRepository().Get(username)
                        });
                }
                return false;
            }

            return true;
        }
    }
}
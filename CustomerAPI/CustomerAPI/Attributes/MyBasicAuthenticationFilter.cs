using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using DAL.Facade.Implementation;

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
            Facade facade = new Facade();

            if (facade.GetCompanyRepository().AuthenticateCompany(username, password))
            {
                return true;
            }

            return false;
        }
    }
}
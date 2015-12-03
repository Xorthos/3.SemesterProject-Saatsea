using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CustomerManagement.Attributes
{
    public class AuthorizeLoginAttribute : AuthorizeAttribute
    {
        public string Token { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            return SessionHelper.LoginModel;
        }
    }
}
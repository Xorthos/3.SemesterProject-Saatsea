using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerManagement.Attributes
{
    public class SessionHelper
    {
        public static bool LoginModel
        {
            get
            {
                HttpContext context = HttpContext.Current;
                return context.Session["LoginModel"] != null;
            }
            set
            {
                HttpContext context = HttpContext.Current;
                context.Session["LoginModel"] = value;
            }
        }
    }
}
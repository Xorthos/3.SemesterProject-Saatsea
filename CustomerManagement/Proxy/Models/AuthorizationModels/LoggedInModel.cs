﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Models.AuthorizationModels
{
    public class LoggedInModel
    {
        public string Email { get; set; }
        public string AuthenticationToken { get; set; }
    }
}

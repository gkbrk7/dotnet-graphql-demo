﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLSampleAuthenticationAPI.InputTypes
{
    public class LoginInputType
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

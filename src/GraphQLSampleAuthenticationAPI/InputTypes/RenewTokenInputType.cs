using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLSampleAuthenticationAPI.InputTypes
{
    public class RenewTokenInputType
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}

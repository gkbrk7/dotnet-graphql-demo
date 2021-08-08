using GraphQLSampleAuthenticationAPI.InputTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLSampleAuthenticationAPI.Logics
{
    public interface IAuthLogic
    {
        string Register(RegisterInputType registerInput);
        string Login(LoginInputType loginInput);
    }
}

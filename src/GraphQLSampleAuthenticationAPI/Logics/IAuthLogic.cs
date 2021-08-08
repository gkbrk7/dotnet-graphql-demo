using GraphQLSampleAuthenticationAPI.InputTypes;
using GraphQLSampleAuthenticationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLSampleAuthenticationAPI.Logics
{
    public interface IAuthLogic
    {
        string Register(RegisterInputType registerInput);
        TokenResponseModel Login(LoginInputType loginInput);
        TokenResponseModel RenewToken(RenewTokenInputType renewToken);
    }
}

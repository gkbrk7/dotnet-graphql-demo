using GraphQLSampleAuthenticationAPI.InputTypes;
using GraphQLSampleAuthenticationAPI.Logics;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLSampleAuthenticationAPI.GraphQL.Resolvers
{
    public class MutationResolver
    {
        public string Register([Service] IAuthLogic authlogic, RegisterInputType registerInput)
        {
            return authlogic.Register(registerInput);
        }

        public string Login([Service] IAuthLogic authLogic, LoginInputType loginInput)
        {
            return authLogic.Login(loginInput);
        }
    }
}

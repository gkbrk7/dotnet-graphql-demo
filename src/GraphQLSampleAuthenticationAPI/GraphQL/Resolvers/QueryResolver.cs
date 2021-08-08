using GraphQLSampleAuthenticationAPI.Data;
using GraphQLSampleAuthenticationAPI.Data.Entities;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLSampleAuthenticationAPI.GraphQL.Resolvers
{
    public class QueryResolver
    {
        public string Hello()
        {
            return $"Welcome to Hot Chocolate GraphQL Authentication Demo ";
        }

        public User FirstUser([Service] AuthContext authContext)
        {
            var user = authContext.Users.FirstOrDefault();
            return user;
        }
    }
}

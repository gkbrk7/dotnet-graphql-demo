using GraphQLSampleAuthenticationAPI.Data;
using GraphQLSampleAuthenticationAPI.Data.Entities;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Data;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLSampleAuthenticationAPI.GraphQL.Resolvers
{

    public class QueryResolver
    {
        //[Authorize(Policy = "roles-policy")]
        [Authorize(Policy = "claims-policy")]
        public string Hello()
        {
            return $"Welcome to Hot Chocolate GraphQL Authentication Demo ";
        }

        public User FirstUser([Service] AuthContext authContext)
        {
            var user = authContext.Users.FirstOrDefault();
            return user;
        }

        //[UseOffsetPaging(DefaultPageSize = 10, IncludeTotalCount = true, MaxPageSize = 50)]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> AllUsers([Service] AuthContext authContext)
        {
            return authContext.Users;
        }
    }
}

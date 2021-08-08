using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLSampleSubscriptionsDemoAPI.Core
{
    public class QueryObjectType
    {
        public string Hello()
        {
            return $"Hello Pub/Sub Demo API for GraphQL Subscriptions Type";
        }
    }
}

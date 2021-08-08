using GraphQLSampleSubscriptionsDemoAPI.Models;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLSampleSubscriptionsDemoAPI.Core
{
    public class SubscriptionObjectType
    {
        [Subscribe]
        [Topic]
        public Product SubscribeProduct([EventMessage] Product product)
        {
            return product;
        }
    }
}

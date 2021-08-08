using GraphQLSampleSubscriptionsDemoAPI.Models;
using HotChocolate;
using HotChocolate.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLSampleSubscriptionsDemoAPI.Core
{
    public class MutationObjectType
    {
        public async Task<string> AddandPublishProduct([Service] ITopicEventSender eventSender, Product product)
        {
            // Write custom logic like saving to some data store
            await eventSender.SendAsync(nameof(SubscriptionObjectType.SubscribeProduct), product);
            return product.Name;
        }
    }
}

using GraphQLSampleAuthenticationAPI.GraphQL.CoreSchemas;
using HotChocolate.Types;

namespace GraphQLSampleAuthenticationAPI.GraphQL.Models.ObjectTypes
{
    public class QueryObjectType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(_ => _.Welcome()).Type<StringType>().Name("welcome");
        }
    }
}
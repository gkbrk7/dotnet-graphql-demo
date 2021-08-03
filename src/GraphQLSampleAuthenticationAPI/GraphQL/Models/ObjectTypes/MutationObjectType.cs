using GraphQLSampleAuthenticationAPI.GraphQL.CoreSchemas;
using GraphQLSampleAuthenticationAPI.GraphQL.Models.InputObjectTypes;
using HotChocolate.Types;

namespace GraphQLSampleAuthenticationAPI.GraphQL.Models.ObjectTypes
{
    public class MutationObjectType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(_ => _.UserLogin(default, default))
                .Name("userLogin")
                .Type<StringType>()
                .Argument("loginInput", _ => _.Type<LoginInputObjectType>());
        }
    }
}
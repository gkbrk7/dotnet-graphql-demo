using GraphQLSampleAuthenticationAPI.Models;
using HotChocolate.Types;

namespace GraphQLSampleAuthenticationAPI.GraphQL.Models.InputObjectTypes
{
    public class LoginInputObjectType : InputObjectType<LoginInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<LoginInput> descriptor)
        {
            descriptor.Field(_ => _.Email).Type<StringType>().Name("email");
            descriptor.Field(_ => _.Password).Type<StringType>().Name("password");
        }
    }
}
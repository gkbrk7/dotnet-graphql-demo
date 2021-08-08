using GraphQLSampleSplitAPI.InputTypes;
using GraphQLSampleSplitAPI.MutationResolvers;
using HotChocolate.Types;

namespace GraphQLSampleSplitAPI.MutationTypeExtensions
{
    public class CountryMutationTypeExtension : ObjectTypeExtension
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("Mutation");

            descriptor.Field("saveCountry")
                .ResolveWith<CountryMutationResolver>(q => q.SaveCountry(default))
                .Argument("model", _ => _.Type<CountryInput>())
                .Type<StringType>()
                .Name("saveCountry");
        }
    }
}
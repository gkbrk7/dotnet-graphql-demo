using GraphQLSampleSplitAPI.QueryResolvers;
using HotChocolate.Types;

namespace GraphQLSampleSplitAPI.TypeExtensions
{
    public class CountryTypeExtension : ObjectTypeExtension
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("Query");

            descriptor.Field("GetHomeTown")
                .ResolveWith<CountryQueryResolver>(q => q.GetHometown())
                .Type<StringType>()
                .Name("getHomeTown");
        }
    }
}
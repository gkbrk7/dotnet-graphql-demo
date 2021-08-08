using GraphQLSampleSplitAPI.Models;
using HotChocolate.Types;

namespace GraphQLSampleSplitAPI.InputTypes
{
    public class CountryInput : InputObjectType<CountryModel>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CountryModel> descriptor)
        {
            descriptor.Name("countryInput");

            descriptor.Field(_ => _.Id).Type<IntType>().Name("id");
            descriptor.Field(_ => _.Name).Type<StringType>().Name("name");
        }
    }
}
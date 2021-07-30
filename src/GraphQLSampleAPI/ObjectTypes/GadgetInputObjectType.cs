using GraphQLSampleAPI.Models;
using HotChocolate.Types;

namespace GraphQLSampleAPI.ObjectTypes
{
    public class GadgetInputObjectType : InputObjectType<GadgetInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<GadgetInput> descriptor)
        {
            descriptor.Field(_ => _.productName).Type<StringType>().Name("ProductName");
            descriptor.Field(_ => _.brandName).Type<StringType>().Name("BrandName");
            descriptor.Field(_ => _.cost).Type<DecimalType>().Name("Cost");
            descriptor.Field(_ => _.type).Type<StringType>().Name("Type");
        }
    }
}
using GraphQLSampleAPI.Models;
using HotChocolate.Types;

namespace GraphQLSampleAPI.ObjectTypes
{
    public class GadgetObjectType : ObjectType<Gadget>
    {
        protected override void Configure(IObjectTypeDescriptor<Gadget> descriptor)
        {
            descriptor.Field(_ => _.id).Type<StringType>().Name("Id");
            descriptor.Field(_ => _.productName).Type<StringType>().Name("ProductName");
            descriptor.Field(_ => _.brandName).Type<StringType>().Name("BrandName");
            descriptor.Field(_ => _.cost).Type<DecimalType>().Name("Cost");
            descriptor.Field(_ => _.type).Type<StringType>().Name("Type");
        }
    }
}
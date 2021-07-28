using GraphQLSampleAPI.Data.Entities;
using HotChocolate.Types;

namespace GraphQLSampleAPI.ObjectTypes
{
    public class GadgetObjectType : ObjectType<Gadget>
    {
        protected override void Configure(IObjectTypeDescriptor<Gadget> descriptor)
        {
            descriptor.Field(_ => _.Id).Type<IntType>().Name("Id");
            descriptor.Field(_ => _.ProductName).Type<StringType>().Name("ProductName");
            descriptor.Field(_ => _.BrandName).Type<StringType>().Name("BrandName");
            descriptor.Field(_ => _.Cost).Type<DecimalType>().Name("Cost");
            descriptor.Field(_ => _.Type).Type<StringType>().Name("Type");
        }
    }
}
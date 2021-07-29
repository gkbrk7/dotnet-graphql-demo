using GraphQLSampleAPI.CoreSchema;
using HotChocolate.Types;

namespace GraphQLSampleAPI.ObjectTypes
{
    public class QueryObjectType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(_ => _.FirstGadget(default)).Type<GadgetObjectType>().Name("firstGadget");
            descriptor.Field(_ => _.Gadgets(default)).Type<ListType<GadgetObjectType>>().Name("allGadgets");
            descriptor.Field(_ => _.GetByBrands(default, default)).Type<ListType<GadgetObjectType>>().Name("allGadgetsByBrand");
        }
    }
}
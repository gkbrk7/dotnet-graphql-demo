using GraphQLSampleAPI.CoreSchema;
using HotChocolate.Types;

namespace GraphQLSampleAPI.ObjectTypes
{
    public class QueryObjectType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(_ => _.FirstGadget()).Type<GadgetObjectType>().Name("firstGadget");
            descriptor.Field(_ => _.Gadgets()).Type<ListType<GadgetObjectType>>().Name("allGadgets");
            descriptor.Field(_ => _.GetByBrands(default)).Type<ListType<GadgetObjectType>>().Name("allGadgetsByBrand");
            descriptor.Field(_ => _.GetByBrandsLoader(default, default, default)).Type<ListType<GadgetObjectType>>().Name("brandFilterLoader");
        }
    }
}
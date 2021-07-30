using GraphQLSampleAPI.CoreSchema;
using HotChocolate.Types;

namespace GraphQLSampleAPI.ObjectTypes
{
    public class MutationObjectType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(_ => _.SaveGadget(default)).Type<GadgetObjectType>().Argument("gadgetInput", _ => _.Type<GadgetInputObjectType>()).Name("addGadget");
        }
    }
}
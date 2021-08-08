using GraphQLSampleSplitAPI.Models;
using HotChocolate.Types;

namespace GraphQLSampleSplitAPI.MutationResolvers
{
    [ExtendObjectType("Mutation")]
    public class PetMutationResolver
    {
        public string SavePet(PetModel model)
        {
            return model.Name;
        }
    }
}
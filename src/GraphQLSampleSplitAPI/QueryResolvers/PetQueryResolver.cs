using HotChocolate.Types;

namespace GraphQLSampleSplitAPI.QueryResolvers
{
    [ExtendObjectType("Query")]
    public class PetQueryResolver
    {
        public string getPet()
        {
            return "Dog";
        }
    }
}
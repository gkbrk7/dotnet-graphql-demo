using GraphQLSampleSplitAPI.Models;

namespace GraphQLSampleSplitAPI.MutationResolvers
{
    public class CountryMutationResolver
    {
        public string SaveCountry(CountryModel model)
        {
            return model.Name;
        }
    }
}
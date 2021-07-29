using Cosmonaut;
using GraphQLSampleAPI.Data.Interfaces;
using GraphQLSampleAPI.Models;

namespace GraphQLSampleAPI.Data.Repositories
{
    public class CosmosGadgetRepositoryAsync : GenericRepositoryAsync<Gadget>, ICosmosGadgetRepository
    {
        public CosmosGadgetRepositoryAsync(ICosmosStore<Gadget> cosmosStore) : base(cosmosStore)
        {

        }
    }
}
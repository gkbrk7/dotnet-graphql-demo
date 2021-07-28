using Cosmonaut;
using GraphQLSampleAPI.Data.Interfaces;
using GraphQLSampleAPI.Models;

namespace GraphQLSampleAPI.Data.Repositories
{
    public class CosmosCarRepositoryAsync : GenericRepositoryAsync<Car>, ICosmosCarRepository
    {
        public CosmosCarRepositoryAsync(ICosmosStore<Car> cosmosStore) : base(cosmosStore)
        {
        }
    }
}
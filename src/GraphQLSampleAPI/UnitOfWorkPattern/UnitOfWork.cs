using System;
using Cosmonaut;
using GraphQLSampleAPI.Data.Interfaces;
using GraphQLSampleAPI.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLSampleAPI.UnitOfWorkPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICosmosCarRepository CosmosCarRepository { get; }
        public ICosmosGadgetRepository CosmosGadgetRepository { get; }

        public UnitOfWork(ICosmosCarRepository cosmosCarRepository, ICosmosGadgetRepository gadgetRepository)
        {
            CosmosGadgetRepository = gadgetRepository;
            CosmosCarRepository = cosmosCarRepository;
        }

        public void Dispose()
        {

        }
    }
}
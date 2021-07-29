using System;
using GraphQLSampleAPI.Data.Interfaces;

namespace GraphQLSampleAPI.UnitOfWorkPattern
{
    public interface IUnitOfWork : IDisposable
    {
        ICosmosCarRepository CosmosCarRepository { get; }
        ICosmosGadgetRepository CosmosGadgetRepository { get; }
    }
}
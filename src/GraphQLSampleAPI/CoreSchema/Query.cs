using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cosmonaut.Extensions;
using GraphQLSampleAPI.Attributes;
using GraphQLSampleAPI.DataLoader;
using GraphQLSampleAPI.Models;
using GraphQLSampleAPI.UnitOfWorkPattern;
using HotChocolate;

namespace GraphQLSampleAPI.CoreSchema
{
    public class Query
    {
        private readonly IUnitOfWork unitOfWork;
        public Query(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Gadget> FirstGadget(/*[Service] IUnitOfWork unitOfWork*/)
        {
            return (await unitOfWork.CosmosGadgetRepository.GetAll()).FirstOrDefault();
        }

        public async Task<IEnumerable<Gadget>> Gadgets()
        {
            return await unitOfWork.CosmosGadgetRepository.GetAll();
        }

        [UseApplicationDbContext]
        public async Task<IEnumerable<Gadget>> GetByBrands(string brand /*[ScopedService] IUnitOfWork unitOfWork*/)
        {
            return await unitOfWork.CosmosGadgetRepository.Find(x => x.brandName.ToLower() == brand.ToLower());
        }

        public async Task<IEnumerable<Gadget>> GetByBrandsLoader(string brand, GadgetsByBrandDataLoader loader, CancellationToken cancellation)
        {
            return await loader.LoadAsync(brand, cancellation);
        }
    }
}
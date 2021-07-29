using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cosmonaut.Extensions;
using GraphQLSampleAPI.Models;
using GraphQLSampleAPI.UnitOfWorkPattern;
using HotChocolate;

namespace GraphQLSampleAPI.CoreSchema
{
    public class Query
    {
        public async Task<Gadget> FirstGadget([Service] IUnitOfWork unitOfWork)
        {
            return (await unitOfWork.CosmosGadgetRepository.GetAll()).FirstOrDefault();
        }

        public async Task<IEnumerable<Gadget>> Gadgets([Service] IUnitOfWork unitOfWork)
        {
            return await unitOfWork.CosmosGadgetRepository.GetAll();
        }

        public async Task<IEnumerable<Gadget>> GetByBrands(string brand, [Service] IUnitOfWork unitOfWork)
        {
            return await unitOfWork.CosmosGadgetRepository.Find(x => x.brandName.ToLower() == brand.ToLower());
        }
    }
}
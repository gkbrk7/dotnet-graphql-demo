using System;
using System.Threading.Tasks;
using GraphQLSampleAPI.Models;
using GraphQLSampleAPI.UnitOfWorkPattern;

namespace GraphQLSampleAPI.CoreSchema
{
    public class Mutation
    {
        private readonly IUnitOfWork unitOfWork;
        public Mutation(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Gadget> SaveGadget(GadgetInput data)
        {
            var gadget = new Gadget
            {
                id = Guid.NewGuid().ToString(),
                brandName = data.brandName,
                cost = data.cost,
                productName = data.productName,
                type = data.type
            };
            return (await unitOfWork.CosmosGadgetRepository.Add(gadget)).Data;
        }
    }
}
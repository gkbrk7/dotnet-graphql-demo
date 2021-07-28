using System.Collections.Generic;
using GraphQLSampleAPI.Data.Entities;

namespace GraphQLSampleAPI.CoreSchema
{
    public class Query
    {
        public Gadget FirstGadget()
        {
            return new Gadget
            {
                Id = 1,
                BrandName = "Samsung",
                ProductName = "Samsung S10",
                Cost = 9000,
                Type = "Phone"
            };
        }

        public IEnumerable<Gadget> Gadgets()
        {
            return new List<Gadget>{
                new Gadget{Id = 1, BrandName = "Samsung", ProductName = "Samsung S10", Cost = 9000, Type = "Phone"},
                new Gadget{Id = 2, BrandName = "Apple", ProductName = "IPhone 11", Cost = 11500, Type = "Phone"},
                new Gadget{Id = 3, BrandName = "Huawei", ProductName = "Mate Pro", Cost = 10000, Type = "Phone"},
            };
        }
    }
}
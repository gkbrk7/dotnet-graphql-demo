using System;

namespace GraphQLSampleAPI.Models
{
    public class Car : AbstractCosmosModel
    {
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}
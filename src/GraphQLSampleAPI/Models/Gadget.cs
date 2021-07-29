using System;

namespace GraphQLSampleAPI.Models
{
    public class Gadget
    {
        public string id { get; set; }
        public string productName { get; set; }
        public string brandName { get; set; }
        public decimal cost { get; set; }
        public string type { get; set; }
    }
}
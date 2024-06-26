namespace Entities.RequestFeatures
{
    public class ProductParameters : RequestParameters
    {
        public uint minPrice { get; set; }
        public uint maxPrice { get; set; } = 1000;
        public bool ValidPriceRange => maxPrice > minPrice;

        public String? SerachTerm { get; set; }

        public ProductParameters()
        {
            OrderBy = "id";
        }
    }
}

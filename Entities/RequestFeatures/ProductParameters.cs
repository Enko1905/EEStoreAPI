namespace Entities.RequestFeatures
{
    public class ProductParameters : RequestParameters
    {
        public uint minPrice { get; set; }
        public uint maxPrice { get; set; } = 1000;
        public bool ValidPriceRange => maxPrice > minPrice;
<<<<<<< HEAD

        public String? SerachTerm { get; set; }

        public ProductParameters()
        {
            OrderBy = "id";
=======
        public String? SearchTerm { get; set; }

        public ProductParameters()
        {
            OrderBy = "Id";
>>>>>>> 475fa9d2df6d15050b6f161b88f099728dd8905c
        }
    }
}

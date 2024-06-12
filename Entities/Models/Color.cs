namespace Entities.Models
{
    public class Color
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public string? ColorCode { get; set; }

        public ICollection<ProductVariants> ProductVariants { get; set; }
    }

}

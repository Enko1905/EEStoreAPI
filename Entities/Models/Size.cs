namespace Entities.Models
{
    public class Size
    {
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public ICollection<ProductVariants> ProductVariants { get; set; }
    }

}

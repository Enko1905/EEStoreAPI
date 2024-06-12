using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    // Ürün Resmi tablosu
    public class ProductImage
    {
        [Key]
        public int ProductImageId { get; set; }
        public string? ImageUrl { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Products Products { get; set; }
    }

}

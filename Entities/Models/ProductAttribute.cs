using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    // Ürün özellikleri tablosu

    public class ProductAttribute
    {
        public int ProductAttributeId { get; set; }
        public string Type { get; set; }

        public string Value { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Products Product { get; set; }

    }

}

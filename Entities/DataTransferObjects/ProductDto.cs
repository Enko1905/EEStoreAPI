using Entities.Models;

namespace Entities.DataTransferObjects
{
    public record ProductDto
    {
        public int ProductId { get; init; }
        public string ProductName { get; init; }
        public int CategoryId { get; init; }
        public String Description { get; init; }
        public Decimal Price { get; init; }
        public int Stock { get; init; }
        public ICollection<ProductImageDto> ProductImages { get; set; }

        public ICollection<ProductAttributeDto> ProductAttributes { get; init; }
        //public ICollection<OrderDetail> OrderDetails { get; init; }
        public ICollection<ProductCustomAttributeDto> productCustomAttributes { get; init; }
        public ICollection<ProductVariantDto> productVariants { get; init; }

    }
}

using Entities.Models;

namespace Entities.DataTransferObjects
{
    public record ProductDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int CategoryId { get; init; }
        public int SubCategoryId { get; init; }

        public String Description { get; init; }
        public decimal Price { get; init; }
        public uint Stock { get; init; }
        public string ImageUrl { get; init; }
        public string? SKU { get; init; }
        public bool Status { get; init; }
        public bool? variousProduct { get; init; }

        private uint totalStock;

        public bool Featured { get; init; }
        public string? Tags { get; init; }
        public decimal? Weight { get; init; }
        public decimal? Width { get; init; }
        public decimal? Height { get; init; }

        public DateTime CreateDate { get; init; } 
        public DateTime? UpdateDate { get; init; }


        public ICollection<ProductImageDto> ProductImages { get; set; }

        public ICollection<ProductAttributeDto> ProductAttributes { get; init; }
        //public ICollection<OrderDetail> OrderDetails { get; init; }
        public ICollection<ProductVariantDto> productVariants { get; init; }

        public uint TotalStock
        {
            get
            {
                return (variousProduct == true && productVariants is not null) ? (uint)(productVariants.Sum(x => x.Stock)) : (uint)Stock;
            }
        }
    }
}

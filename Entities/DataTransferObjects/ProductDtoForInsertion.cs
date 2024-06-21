namespace Entities.DataTransferObjects
{
    public record ProductDtoForInsertion:ProductDtoForManipulation
    {
        public ICollection<ProductImageDto> ?ProductImages { get; set; }
        public ICollection<ProductAttributeDto>? ProductAttributes { get; set; }
        public ICollection<ProductVariantDto>? productVariants { get; set; }
    }
}

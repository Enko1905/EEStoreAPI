namespace Entities.DataTransferObjects
{
    public record ProductDtoForInsertion : ProductDtoForManipulation
    {
        public DateTime CreateDate { get; set; }
        public ProductDtoForInsertion()
        {
            CreateDate = DateTime.UtcNow;
        }
        public ICollection<ProductImageDtoForInsert>? ProductImages { get; set; }
        public ICollection<ProductAttributeDtoForInsert>? ProductAttributes { get; set; }
        public ICollection<ProductVariantsDtoForInsert>? productVariants { get; set; }
    }
}

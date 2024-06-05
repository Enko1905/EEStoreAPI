namespace Entities.DataTransferObjects
{
    public record ProductDto
    {
        public int Id { get; init; }
        public string ProductName { get; init; }
        public int CategoryId { get; init; }
        public String Description { get; init; }
        public Decimal Price { get; init; }
        public int Stok { get; init; }
    }
}

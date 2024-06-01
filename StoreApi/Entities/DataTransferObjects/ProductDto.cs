namespace Entities.DataTransferObjects
{
    public record ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public String Description { get; set; }
        public Decimal Price { get; set; }
        public int Stok { get; set; }
    }
}

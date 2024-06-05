namespace Entities.Exceptions
{
    //sealed class kalıtım yapılamaz
    public sealed class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(int id) : base($"The Produc with id {id} cloud not found.")
        {
                
        }
    }
}

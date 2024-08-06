using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Entities.DataTransferObjects;
using Entities.RequestFeatures;
using System.Dynamic;
namespace Services.Contracts
{
    public interface IProductService
    {
        Task<(IEnumerable<ExpandoObject>,MetaData metaData)> GetAllProductAsync(ProductParameters productParameters, bool trachChanges);
        Task<ProductDto> GetOneProductByIdAsync(int id, bool trackChanges);

        Task<ProductDto> CreateOneProductAsync(ProductDtoForInsertion products);
        Task UpdateOneProductAsync(int id, ProductDtoForUpdate productsDto);
        Task DeleteOneProductAsync(int id, bool trackChanges);
        Task<(ProductDtoForUpdate productDtoForUpdate, Products products)> GetOneProductForPatchAsync(int id, bool trachChanges);
    
        Task SaveChangesForPatchAsync(ProductDtoForUpdate productDtoForUpdate, Products products);
        
    }
}

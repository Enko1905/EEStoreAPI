using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Entities.DataTransferObjects;
using Entities.RequestFeatures;
using System.Dynamic;
<<<<<<< HEAD
=======
using Entities.LinkModels;
>>>>>>> 475fa9d2df6d15050b6f161b88f099728dd8905c
namespace Services.Contracts
{
    public interface IProductService
    {
<<<<<<< HEAD
        Task<(IEnumerable<ExpandoObject>,MetaData metaData)> GetAllProductAsync(ProductParameters productParameters, bool trachChanges);
=======
        Task<(IEnumerable<ProductDto>,MetaData metaData)> GetAllProductAsync(ProductParameters productParameters, bool trachChanges);

        Task<(LinkResponse linkResponse, MetaData metaData)> GetAllProductWithAttiributeAsync(LinkParameters linkParameters, bool trachChanges);


>>>>>>> 475fa9d2df6d15050b6f161b88f099728dd8905c
        Task<ProductDto> GetOneProductByIdAsync(int id, bool trackChanges);

        Task<ProductDto> CreateOneProductAsync(ProductDtoForInsertion products);
        Task UpdateOneProductAsync(int id, ProductDtoForUpdate productsDto);
        Task DeleteOneProductAsync(int id, bool trackChanges);
        Task<(ProductDtoForUpdate productDtoForUpdate, Products products)> GetOneProductForPatchAsync(int id, bool trachChanges);
    
        Task SaveChangesForPatchAsync(ProductDtoForUpdate productDtoForUpdate, Products products);
        Task<ProductDto> GetOneProductWithAttributeAsync(int id, bool trackChanges);

    }
}

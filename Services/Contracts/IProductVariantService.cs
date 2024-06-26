using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IProductVariantService
    {
        Task<IEnumerable<ProductVariantDto>> GetAllProductVariantsSkuCodeAsync(int id, bool trackChanges);
        Task<ProductVariantDto> GetOneProductVariantsSkuCodeAync(int id, bool trackChanges);
        Task CreateOneProductVariantsAsync(ProductVariantsDtoForInsert ProductVariantsDto);
        Task UpdateOneProductVariantsAsync(int id, ProductVariantsDtoForUpdate ProductVariantsDto,bool trackChanges);
        Task DeleteOneProductVariantsAsync(int id, bool trackChanges);
    }
}

using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IProductVariantRepository:IRepositoryBase<ProductVariants>
    {
        Task<IEnumerable<ProductVariants>> GetAllProductVariantsSkuCodeAsync(int  id ,bool trackChanges);
        Task<ProductVariants> GetOneProductVariantsSkuCodeAync(int id, bool trackChanges);
        void CreateOneProductVariants(ProductVariants ProductVariants);
        void UpdateOneProductVariants(ProductVariants ProductVariants);
        void DeleteOneProductVariants(ProductVariants ProductVariants);
    }
}

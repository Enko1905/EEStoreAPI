using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class ProductVariantRepository : RepositoryBase<ProductVariants>, IProductVariantRepository
    {
        public ProductVariantRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneProductVariants(ProductVariants ProductVariants) => Create(ProductVariants);


        public void DeleteOneProductVariants(ProductVariants ProductVariants) => Delete(ProductVariants);


        public async Task<IEnumerable<ProductVariants>> GetAllProductVariantsSkuCodeAsync(int id, bool trackChanges)
        {
            return await FindByCondition(x => x.ProductId==id, trackChanges)
                .Include(p=>p.Products)
                .Include(p=>p.Color)
                .Include(p=>p.Size)
                .OrderByDescending(x => x.VariantId)
                .ToListAsync();
        }


        public async Task<ProductVariants> GetOneProductVariantsSkuCodeAync(int id, bool trackChanges)
        {
            return await FindByCondition(x => x.VariantId==id, trackChanges)
           .Include(p => p.Products)
           .Include(p => p.Color)
           .Include(p => p.Size)
           .SingleOrDefaultAsync();
        }

        public void UpdateOneProductVariants(ProductVariants ProductVariants) =>Create(ProductVariants);
       
    }
}

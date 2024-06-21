using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public sealed class ProductRepository : RepositoryBase<Products>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {

        }
        public void CreateOneProduct(Products products) => Create(products);

        public void DeleteOneProduct(Products products) => Delete(products);

        public async Task<PagedList<Products>> GetAllProductAsync(ProductParameters productParameters, bool trackChanges)
        {
            var products = await FindAll(trackChanges)
            .FilterProducts(productParameters.minPrice, productParameters.maxPrice)
            .OrderBy(x => x.ProductId)
            .ToListAsync();

            return PagedList<Products>.ToPagedList(products,
                productParameters.PageNumber,
                productParameters.PageSize);
        }

        public async Task<PagedList<Products>> GetAllProductWithAttributeAsync(ProductParameters productParameters, bool trackChanges)
        {
            var products = await FindAll(trackChanges)
                .Include(p => p.ProductAttributes)
                .Include(p => p.ProductImages)
                .Include(p => p.productVariants)
                    .ThenInclude(c => c.Color)
                .Include(p => p.productVariants)

            .FilterProducts(productParameters.minPrice, productParameters.maxPrice)
            .OrderBy(x => x.ProductId)
            .ToListAsync();



            return PagedList<Products>.ToPagedList(products,
                productParameters.PageNumber,
                productParameters.PageSize);
        }

        public async Task<Products> GetOneProductByIdAync(int id, bool trackChanges) =>
             await FindByCondition(x => x.ProductId == id, trackChanges).SingleOrDefaultAsync();

        public async Task<Products> GetOneProductWithAttributeAsync(int id, bool trackChanges)
        {
            var products = await FindAll(trackChanges)
                .Include(p => p.ProductAttributes)
                .Include(p => p.ProductImages)
                .Include(p => p.productVariants)
                    .ThenInclude(c => c.Color)
                .Include(p => p.productVariants)
            .FirstOrDefaultAsync(a => a.ProductId==id);
            return products;
        }

        public void UpdateOneProduct(Products products) => Update(products);

    }
}

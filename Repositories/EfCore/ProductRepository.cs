﻿using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.Extensions;
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
            .Search(productParameters.SerachTerm)
            .Sort(productParameters.OrderBy)
            .OrderBy(x => x.Id)
            .ToListAsync();

            return PagedList<Products>.ToPagedList(products,
                productParameters.PageNumber,
                productParameters.PageSize);
        }

        public async Task<Products> GetOneProductByIdAync(int id, bool trackChanges) =>
             await FindByCondition(x => x.Id == id, trackChanges).SingleOrDefaultAsync();

        public void UpdateOneProduct(Products products) => Update(products);

    }
}

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
    public class ProductRepository : RepositoryBase<Products>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {

        }
        public void CreateOneProduct(Products products) => Create(products);

        public void DeleteOneProduct(Products products) => Delete(products);

        public async Task<IEnumerable<Products>> GetAllProductAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(x => x.Id)
            .ToListAsync();

        public async Task<Products> GetOneProductByIdAync(int id, bool trackChanges) =>
             await FindByCondition(x => x.Id == id, trackChanges).SingleOrDefaultAsync();

        public void UpdateOneProduct(Products products) => Update(products);

    }
}

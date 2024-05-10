using Entities.Models;
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
        void IProductRepository.CreateOneProduct(Products products) => Create(products);

        void IProductRepository.DeleteOneProduct(Products products) => Delete(products);

        IQueryable<Products> IProductRepository.GetAllProduct(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(x => x.Id);

        Products IProductRepository.GetOneProductById(int id, bool trackChanges) =>
             FindByCondition(x => x.Id == id, trackChanges).SingleOrDefault();

        void IProductRepository.UpdateOneProduct(Products products) => Update(products);

    }
}

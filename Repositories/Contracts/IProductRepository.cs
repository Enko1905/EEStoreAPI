using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Products>
    {
        IQueryable<Products> GetAllProduct(bool trackChanges);
        Products GetOneProductById(int id, bool trackChanges);
        void CreateOneProduct(Products products);
        void UpdateOneProduct(Products products);
        void DeleteOneProduct(Products products);

    }
}

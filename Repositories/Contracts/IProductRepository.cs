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
        Task<IEnumerable<Products>> GetAllProductAsync(bool trackChanges);
        Task<Products> GetOneProductByIdAync(int id, bool trackChanges);
        void CreateOneProduct(Products products);
        void UpdateOneProduct(Products products);
        void DeleteOneProduct(Products products);

    }
}

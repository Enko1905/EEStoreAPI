using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Products> GetAllProduct(bool trachChanges);
        Products GetOneProductById(int id, bool trackChanges);
        Products CreateOneProduct(Products products);
        void UpdateOneProduct(int id, Products products);
        void DeleteOneProduct(int id, bool trackChanges);


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Entities.DataTransferObjects;
namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllProduct(bool trachChanges);
        Products GetOneProductById(int id, bool trackChanges);
        Products CreateOneProduct(Products products);
        void UpdateOneProduct(int id, ProductDtoForUpdate productsDto);
        void DeleteOneProduct(int id, bool trackChanges);


    }
}

using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        public ProductManager(IRepositoryManager manager, ILoggerService logger)
        {
            _manager = manager;
            _logger = logger;
        }
        public Products CreateOneProduct(Products products)
        {
            _manager.Product.Create(products);
            _manager.Save();
            return products;
        }



        public void DeleteOneProduct(int id, bool trackChanges)
        {
            var entity = _manager.Product.GetOneProductById(id, false);
            if (entity is null)
            {
                string message = $"Product With id : {id} could not found.";
                _logger.LogInfo(message);
                throw new Exception(message);
            }
            _manager.Product.Delete(entity);
            _manager.Save();
        }

        public IEnumerable<Products> GetAllProduct(bool trachChanges)
        {
            return _manager.Product.GetAllProduct(trachChanges);
        }

        public Products GetOneProductById(int id, bool trackChanges)
        {
            return _manager.Product.GetOneProductById(id, trackChanges);
        }

        public void UpdateOneProduct(int id, Products products)
        {
            var entity = _manager.Product.GetOneProductById(id, false);
            if (entity is null)
            {
                string message = $"Product With id : {id} could not found.";
                _logger.LogInfo(message);
                throw new Exception(message);

            }
            if (products is null)
            {
                throw new ArgumentException(nameof(products));
            }
            entity.ProductName = products.ProductName;
            entity.Stok = products.Stok;
            entity.Price = products.Price;
            entity.Description = products.Description;

            _manager.Product.Update(entity);
            _manager.Save();

        }
    }
}

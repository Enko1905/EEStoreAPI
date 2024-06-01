using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
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
        private readonly IMapper _mapper;
        public ProductManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
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
                throw new ProductNotFoundException(id);
            }
            _manager.Product.Delete(entity);
            _manager.Save();
        }

        public IEnumerable<ProductDto> GetAllProduct(bool trachChanges)
        {
            var product = _manager.Product.GetAllProduct(trachChanges);
            return _mapper.Map<IEnumerable<ProductDto>>(product);
        }

        public Products GetOneProductById(int id, bool trackChanges)
        {
            var book = _manager.Product.GetOneProductById(id, trackChanges);
            if (book is null)
            {
                throw new ProductNotFoundException(id);
            }
            return book;
        }

        public void UpdateOneProduct(int id, ProductDtoForUpdate productDto)
        {
            var entity = _manager.Product.GetOneProductById(id, false);
            if (entity is null)
            {
                throw new ProductNotFoundException(id);
            }
            
            //entity.ProductName = products.ProductName;
            //entity.Stok = products.Stok;
            //entity.Price = products.Price;
            //entity.Description = products.Description;
            entity = _mapper.Map<Products>(productDto);

            _manager.Product.Update(entity);
            _manager.Save();

        }
    }
}

using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductAttributeManager : IProductAttributeService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductAttributeManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task CreateProductAttributeAsync(ProductAttributeDtoForInsert productAttributeDto)
        {
            var entity = _mapper.Map<ProductAttribute>(productAttributeDto);
            _manager.ProductAttribute.Create(entity);
            await _manager.SaveAsync();
        }

        public async Task DeleteProductAttributeAsync(int id)
        {
            var entity = await GetOneProductAttributeByIdAndCheckExists(id, false);
            _manager.ProductAttribute.Delete(entity);
            await _manager.SaveAsync();
        }

        public async Task UpdateProductAttributeAsync(int id, ProductAttributeDtoForUpdate productAttributeDto)
        {
            await GetOneProductAttributeByIdAndCheckExists(id, false);

            var entity = _mapper.Map<ProductAttribute>(productAttributeDto);
            _manager.ProductAttribute.Update(entity);
            await _manager.SaveAsync();
        }
        public async Task<ProductAttribute> GetOneProductAttributeByIdAndCheckExists(int id, bool trackChanges)
        {
            var entity = await _manager.ProductAttribute.FindByCondition(x => x.ProductAttributeId == id, trackChanges).SingleOrDefaultAsync();
            if (entity is null)
            {
                throw new ProductNotFoundException(id);
            }
            return entity;
        }
    }
}

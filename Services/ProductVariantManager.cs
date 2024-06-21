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
    public class ProductVariantManager : IProductVariantService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public ProductVariantManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }


        public async Task CreateOneProductVariants(ProductVariantsDtoForInsert ProductVariantsDto)
        {
            var entity = _mapper.Map<ProductVariants>(ProductVariantsDto);
            _manager.ProductVariant.Create(entity);
            await _manager.SaveAsync();
        }

        public async Task DeleteOneProductVariants(int id, bool trackChanges)
        {
            var entity = await GetOneProductVariantsByIdAndCheckExists(id, trackChanges);
            _manager.ProductVariant.Delete(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<ProductVariantDto>> GetAllProductVariantsSkuCodeAsync(int id, bool trackChanges)
        {
            var entity = await _manager.ProductVariant.GetAllProductVariantsSkuCodeAsync(id, trackChanges);
            return _mapper.Map<IEnumerable<ProductVariantDto>>(entity);
        }

        public async Task<ProductVariantDto> GetOneProductVariantsSkuCodeAync(int  id, bool trackChanges)
        {
            var entity = await _manager.ProductVariant.GetOneProductVariantsSkuCodeAync(id, trackChanges);
            return _mapper.Map<ProductVariantDto>(entity);
        }

        public async Task UpdateOneProductVariants(int id, ProductVariantsDtoForUpdate ProductVariantsDto, bool trackChanges)
        {
            await GetOneProductVariantsByIdAndCheckExists(id, trackChanges);
            var entity = _mapper.Map<ProductVariants>(ProductVariantsDto);
            _manager.ProductVariant.Update(entity);
            await _manager.SaveAsync();
        }
        public async Task<ProductVariants> GetOneProductVariantsByIdAndCheckExists(int id, bool trackChanges)
        {
            var entity = await _manager.ProductVariant.FindByCondition(x => x.VariantId == id, trackChanges).SingleOrDefaultAsync();
            if (entity is null)
            {
                throw new ProductNotFoundException(id);
            }
            return entity;
        }
    }
}

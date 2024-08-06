using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
        private readonly IDataShaper<ProductDto> _shaper;
        public ProductManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper,IDataShaper<ProductDto> shaper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
            _shaper = shaper;
        }
        public async Task<ProductDto> CreateOneProductAsync(ProductDtoForInsertion productsDto)
        {
            var entity = _mapper.Map<Products>(productsDto);
            _manager.Product.Create(entity);
            await _manager.SaveAsync();
            return _mapper.Map<ProductDto>(entity);
        }

        public async Task DeleteOneProductAsync(int id, bool trackChanges)
        {
            var entity = await GetOneProductByIdAndCheckExists(id, trackChanges);
            _manager.Product.Delete(entity);
            await _manager.SaveAsync();
        }

        public async Task<(IEnumerable<ExpandoObject>, MetaData metaData)> GetAllProductAsync(ProductParameters productParameters, bool trachChanges)
        {
            if (!productParameters.ValidPriceRange)
                throw new PriceOutofRangeBadRequestException();

            var productWithsMetaData = await _manager.Product
                .GetAllProductAsync(productParameters, trachChanges);
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(productWithsMetaData);

            var shapedData = _shaper.ShapeData(productDto, productParameters.Fields);
            return (books : shapedData, metaData : productWithsMetaData.MetaData);
        }

        public async Task<ProductDto> GetOneProductByIdAsync(int id, bool trackChanges)
        {
            var product = await GetOneProductByIdAndCheckExists(id, trackChanges);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<(ProductDtoForUpdate productDtoForUpdate, Products products)> GetOneProductForPatchAsync(int id, bool trachChanges)
        {
            var product = await _manager.Product.GetOneProductByIdAync(id, trachChanges);
            if (product is null)
            {
                throw new ProductNotFoundException(id);
            }
            var productDtoForUpdate = _mapper.Map<ProductDtoForUpdate>(product);
            return (productDtoForUpdate, product);
        }

        public async Task SaveChangesForPatchAsync(ProductDtoForUpdate productDtoForUpdate, Products products)
        {
            _mapper.Map(productDtoForUpdate, products);
            await _manager.SaveAsync();
        }

        public async Task UpdateOneProductAsync(int id, ProductDtoForUpdate productDto)
        {
            var entity = await GetOneProductByIdAndCheckExists(id, false);

            //entity.ProductName = products.ProductName;
            //entity.Stok = products.Stok;
            //entity.Price = products.Price;
            //entity.Description = products.Description;
            entity = _mapper.Map<Products>(productDto);

            _manager.Product.Update(entity);
            await _manager.SaveAsync();

        }

        public async Task<Products> GetOneProductByIdAndCheckExists(int id, bool trackChanges)
        {
            var entity = await _manager.Product.GetOneProductByIdAync(id, false);
            if (entity is null)
            {
                throw new ProductNotFoundException(id);
            }
            return entity;
        }
    }
}

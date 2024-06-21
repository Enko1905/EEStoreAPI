using AutoMapper;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IMainCategoryService> _mainCategoryService;
        private readonly Lazy<ISubCategoryService> _subCategoryService;
        private readonly Lazy<IProductAttributeService> _productAttributeService;
        private readonly Lazy<IProductVariantService> _productVariantService;   
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerService logger, IMapper mapper)
        {
            _productService = new Lazy<IProductService>(() => new ProductManager(repositoryManager, logger, mapper));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryManager(repositoryManager, mapper));
            _mainCategoryService = new Lazy<IMainCategoryService>(() => new MainCategoryManager(repositoryManager, mapper));
            _subCategoryService = new Lazy<ISubCategoryService>(() => new SubCategoryManager(repositoryManager, mapper));
            _productAttributeService = new Lazy<IProductAttributeService>(() => new ProductAttributeManager(repositoryManager, mapper));
            _productVariantService = new Lazy<IProductVariantService>(() => new ProductVariantManager(repositoryManager, mapper));
        }
        public IProductService ProductService => _productService.Value;

        public ICategoryService CategoryService => _categoryService.Value;

        public IMainCategoryService MainCategoryService => _mainCategoryService.Value;

        public ISubCategoryService SubCategoryService => _subCategoryService.Value;

        public IProductAttributeService ProductAttributeService => _productAttributeService.Value;

        public IProductVariantService ProductVariantService => _productVariantService.Value;
    }
}

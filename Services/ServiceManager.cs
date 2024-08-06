﻿using AutoMapper;
using Entities.DataTransferObjects;
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
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerService logger , IMapper mapper, IDataShaper<ProductDto> shaper)
        {
            _productService = new Lazy<IProductService>(() => new ProductManager(repositoryManager,logger,mapper,shaper));
        }
        public IProductService ProductService => _productService.Value;
    }
}

using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IProductAttributeRepository:IRepositoryBase<ProductAttribute>
    {
        void CreateProductAttribute(ProductAttribute productAttribute);
        void UpdateProductAttribute(ProductAttribute productAttribute);
        void DeleteProductAttribute(ProductAttribute productAttribute);
    }
}

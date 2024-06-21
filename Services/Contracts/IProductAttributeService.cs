using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IProductAttributeService
    {
        Task CreateProductAttribute(ProductAttributeDtoForInsert productAttributeDto);
        Task UpdateProductAttribute(int id,ProductAttributeDtoForUpdate productAttributeDto);
        Task DeleteProductAttribute(int id);
    }
}

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
        Task CreateProductAttributeAsync(ProductAttributeDtoForInsert productAttributeDto);
        Task UpdateProductAttributeAsync(int id,ProductAttributeDtoForUpdate productAttributeDto);
        Task DeleteProductAttributeAsync(int id);
    }
}

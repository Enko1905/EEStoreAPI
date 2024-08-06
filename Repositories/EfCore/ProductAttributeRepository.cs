using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class ProductAttributeRepository : RepositoryBase<ProductAttribute>, IProductAttributeRepository
    {
        public ProductAttributeRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateProductAttribute(ProductAttribute productAttribute)=>Create(productAttribute);


        public void DeleteProductAttribute(ProductAttribute productAttribute) => Delete(productAttribute);
   

        public void UpdateProductAttribute(ProductAttribute productAttribute) =>Update(productAttribute);   
     
       
    }
}

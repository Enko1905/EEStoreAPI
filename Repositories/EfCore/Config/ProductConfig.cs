using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore.Config
{
    internal class ProductConfig : IEntityTypeConfiguration<Products>

    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasData(
                new Products { ProductId = 1, ProductName = "Demo Product Name", CategoryId = 1, Price = 0, Description = "Demo Description", Stock = 1 },
                 new Products { ProductId = 2, ProductName = "Demo Product Name_1", CategoryId = 2, Price = 0, Description = "Demo Description_1", Stock = 2 },
                  new Products { ProductId = 3, ProductName = "Demo Product Name_2", CategoryId = 3, Price = 0, Description = "Demo Description_2", Stock = 3 });
        }
    }
}

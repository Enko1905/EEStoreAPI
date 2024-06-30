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
                new Products { Id = 1, Name = "Demo Product Name", CategoryId = 1, Price = 0, Description = "Demo Description", Stock = 1 },
                 new Products { Id = 2, Name = "Demo Product Name_1", CategoryId = 2, Price = 0, Description = "Demo Description_1", Stock = 2 },
                  new Products { Id = 3, Name = "Demo Product Name_2", CategoryId = 3, Price = 0, Description = "Demo Description_2", Stock = 3 });
        }
    }
}

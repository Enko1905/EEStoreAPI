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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { CategoryId = 1, Name = "Demo Category" },
            new Category { CategoryId = 2, Name = "Demo Category2" },
            new Category { CategoryId = 3, Name = "Demo Category3" });



        }
    }
}

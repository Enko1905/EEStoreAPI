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
    public class CategoryConfig : IEntityTypeConfiguration<Categories>
    {

        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.HasData(
                new Categories { CategoryId = 1, CategoyName = "Demo Category" },
            new Categories { CategoryId = 2, CategoyName = "Demo Category2" },
            new Categories { CategoryId = 3, CategoyName = "Demo Category3" });



        }
    }
}

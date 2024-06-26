using Entities.DataTransferObjects;
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
    public class MainCategoryConfig : IEntityTypeConfiguration<MainCategory>
    {
        public void Configure(EntityTypeBuilder<MainCategory> builder)
        {
            builder.HasData(
            new MainCategory { MainCategoryId = 1, Name = "Erkek", Description = "Erkek giyim kategorisi", MainCategoryStasus = true, MetaDescription = "Erkek giyim ürünleri kategorisi", MetaTitle = "Erkek Giyim" },
            new MainCategory { MainCategoryId = 2, Name = "Kadın", Description = "Kadın giyim kategorisi", MainCategoryStasus = true, MetaDescription = "Kadın giyim ürünleri kategorisi", MetaTitle = "Kadın Giyim" },
            new MainCategory { MainCategoryId = 3, Name = "Çocuk", Description = "Çocuk giyim kategorisi", MainCategoryStasus = true, MetaDescription = "Çocuk giyim ürünleri kategorisi", MetaTitle = "Çocuk Giyim" },
            new MainCategory { MainCategoryId = 4, Name = "Teknoloji", Description = "Teknoloji ürünleri kategorisi", MainCategoryStasus = true, MetaDescription = "Teknoloji ürünleri kategorisi", MetaTitle = "Teknoloji Ürünleri" },
            new MainCategory { MainCategoryId = 5, Name = "Kozmetik", Description = "Kozmetik ürünleri kategorisi", MainCategoryStasus = true, MetaDescription = "Kozmetik ürünleri kategorisi", MetaTitle = "Kozmetik Ürünleri" } );


        }
    }
}


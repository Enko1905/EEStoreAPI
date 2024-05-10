using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.EfCore.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Repositories.EfCore
{
    public class RepositoryContext : DbContext
    {

        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Veritabanındaki sütun adını belirtin
            //base.OnModelCreating(modelBuilder);
    



             modelBuilder.ApplyConfiguration(new ProductConfig());
             modelBuilder.ApplyConfiguration(new CategoryConfig());

        }
    }
}

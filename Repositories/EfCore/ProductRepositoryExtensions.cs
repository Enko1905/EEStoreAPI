using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public static class ProductRepositoryExtensions
    {
        public static IQueryable<Products> FilterProducts
            (this IQueryable<Products> products, uint minPrace, uint maxPrice) =>
            products.Where(product =>
            (product.Price >= minPrace) &&
            (product.Price <= maxPrice));
    }
}

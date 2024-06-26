using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Repositories.Extensions
{
    public static class ProductRepositoryExtensions
    {
        public static IQueryable<Products> FilterProducts
            (this IQueryable<Products> products, uint minPrace, uint maxPrice) =>
            products.Where(product =>
            product.Price >= minPrace &&
            product.Price <= maxPrice);

        public static IQueryable<Products> Search(this IQueryable<Products> products, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) //Boşluk karakteri veya null olup olmadığı Kontrol Edilir 
                return products;
            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return products.Where(p => p.ProductName.ToLower().Contains(lowerCaseTerm))
                   .Union(products.Where(p => p.Description.ToLower().Contains(lowerCaseTerm)));

        }

        public static IQueryable<Products> Sort
    (this IQueryable<Products> products, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return products.OrderBy(b => b.ProductId);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Products>(orderByQueryString);

            if (orderQuery is null)
                return products.OrderBy(b => b.ProductId);

            return products.OrderBy(orderQuery);


        }

    }
}


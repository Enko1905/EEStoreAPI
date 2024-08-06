using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
using System.Reflection;
=======
>>>>>>> 475fa9d2df6d15050b6f161b88f099728dd8905c
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
<<<<<<< HEAD
        public static IQueryable<Products> Search
            (this IQueryable<Products> products, string searchTerm)
=======

        public static IQueryable<Products> Search(this IQueryable<Products> products, string searchTerm)
>>>>>>> 475fa9d2df6d15050b6f161b88f099728dd8905c
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) //Boşluk karakteri veya null olup olmadığı Kontrol Edilir 
                return products;
            var lowerCaseTerm = searchTerm.Trim().ToLower();

<<<<<<< HEAD
            return products
                .Where(p => p.ProductName
                .ToLower()
                .Contains(searchTerm));
        }

        public static IQueryable<Products> Sort
            (this IQueryable<Products> products, string orderByQueryString)
=======
            return products.Where(p => p.Name.ToLower().Contains(lowerCaseTerm))
                   .Union(products.Where(p => p.Description.ToLower().Contains(lowerCaseTerm)));

        }

        public static IQueryable<Products> Sort
    (this IQueryable<Products> products, string orderByQueryString)
>>>>>>> 475fa9d2df6d15050b6f161b88f099728dd8905c
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return products.OrderBy(b => b.Id);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Products>(orderByQueryString);

            if (orderQuery is null)
                return products.OrderBy(b => b.Id);

            return products.OrderBy(orderQuery);


        }

<<<<<<< HEAD

    }
}
=======
    }
}

>>>>>>> 475fa9d2df6d15050b6f161b88f099728dd8905c

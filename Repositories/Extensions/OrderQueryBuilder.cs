<<<<<<< HEAD
﻿using Entities.Models;
using System;
=======
﻿using System;
>>>>>>> 475fa9d2df6d15050b6f161b88f099728dd8905c
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Extensions
{
    public static class OrderQueryBuilder
    {
<<<<<<< HEAD
        public static String CreateOrderQuery<T>(String orderByQueryString) 
=======
        public static String CreateOrderQuery<T>(String orderByQueryString)
>>>>>>> 475fa9d2df6d15050b6f161b88f099728dd8905c
        {
            var orderByParamans = orderByQueryString.Trim().Split(',');

            //Public ve nivlenebilir ifadelere erişim
            var propertInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            //Sql Sorgları queryStringBuilder tarafından Birleştirilecek
            var orderQueryBuilder = new StringBuilder();

            //Çıktı Örnek : name ascending, price descending, id ascending
            foreach (var param in orderByParamans)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(' ')[0];

                var ObjectPropert = propertInfos
                    .FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (ObjectPropert is null)
                    continue;
                var direction = param.EndsWith(" desc") ? "descending" : "ascending";

                orderQueryBuilder.Append($"{ObjectPropert.Name.ToString()} {direction}");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            return orderQuery;
<<<<<<< HEAD
        } 
=======
        }
>>>>>>> 475fa9d2df6d15050b6f161b88f099728dd8905c
    }
}

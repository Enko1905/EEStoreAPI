using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Entities.DataTransferObjects
{
    public record ProductDtoForUpdate
    {
        public ProductDtoForUpdate(int id, string productName, int stok, string description, decimal price, int categoryId)
        {
            Id = id;
            ProductName = productName;
            Stok = stok;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }
        public int Id { get; init; }
        public string ProductName { get; init; }
        public int CategoryId { get; init; }
        public String Description { get; init; } 
        public Decimal Price { get; init; }
        public int Stok { get; init; }
    }

}

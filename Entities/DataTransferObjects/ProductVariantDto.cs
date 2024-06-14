using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record ProductVariantDto
    {
        [Key]
        public int VariantId { get; init; }
        public int ProductId { get; init; }
        public int ColorId { get; init; }
        public ColorDto Color { get; init; }
        public int SizeId { get; init; }
        public SizeDto Size { get; init; }
        public string SKU { get; init; }
        public int StockQuantity { get; init; }
    }
}

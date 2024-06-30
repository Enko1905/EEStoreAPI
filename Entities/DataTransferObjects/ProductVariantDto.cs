using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Entities.DataTransferObjects
{
    public record ProductVariantDto
    {
        public int Id { get; init; }
        public int ProductId { get; init; }
        public int ColorId { get; init; }
        public ColorDto? Color { get; init; }
        public int SizeId { get; init; }
        public SizeDto? Size { get; init; }
        public string? SKU { get; set; }

        public uint Stock { get; init; }
    }

    public abstract record ProductVariantsForManipulation
    {

        public int ProductId { get; set; }

        public int ColorId { get; set; }

        public int SizeId { get; set; }

        public string? SKU { get; set; }

        [Required(ErrorMessage = "Stok Miktarı gereklidir.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stok Miktarı negatif olamaz.")]
        public uint Stock { get; set; }
    }
    public record ProductVariantsDtoForInsert : ProductVariantsForManipulation
    {
        public ColorDto? Color { get; set; }
        public SizeDto? Size { get; set; }


    }
    public record ProductVariantsDtoForUpdate : ProductVariantsForManipulation
    {
        public int Id { get; set; }
        public ColorDto? Color { get; set; }
        public SizeDto? Size { get; set; }

    }


}

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
        public int VariantId { get; init; }
        public int ProductId { get; init; }
        public int ColorId { get; init; }
        public ColorDto Color { get; init; }
        public int SizeId { get; init; }
        public SizeDto Size { get; init; }
        public uint Stock { get; init; }
    }

    public abstract record ProductVariantsForManipulation
    {

        [Required(ErrorMessage = "Ürün ID'si gereklidir.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Renk ID'si gereklidir.")]
        public int ColorId { get; set; }

        [Required(ErrorMessage = "Beden ID'si gereklidir.")]
        public int SizeId { get; set; }

        [MaxLength(150, ErrorMessage = "SKU 150 karakterden uzun olamaz.")]

        [Required(ErrorMessage = "Stok Miktarı gereklidir.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stok Miktarı negatif olamaz.")]
        public uint Stock { get; set; }
    }
    public record ProductVariantsDtoForInsert : ProductVariantsForManipulation
    {
        public ColorDto Color { get; set; }
        public SizeDto Size { get; set; }


    }
    public record ProductVariantsDtoForUpdate : ProductVariantsForManipulation
    {
        public int VariantId { get; set; }
        public ColorDto Color { get; set; }
        public SizeDto Size { get; set; }

    }


}

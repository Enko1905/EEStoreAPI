using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public abstract record ProductDtoForManipulation
    {
        [Required(ErrorMessage = "Ürün Adı Boş Geçilemez ")]
        [MaxLength(1500, ErrorMessage = "Maxsimum 1500 Karakter Olmalı")]
        public string Name { get; set; }
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "AltKategorş Boş Geçilemez ")]
        public int SubCategoryId { get; set; }

        [Required(ErrorMessage = "Açıklama  Boş Geçilemez ")]
        public String Description { get; set; }

        [Required(ErrorMessage = "Fiyat Boş Geçilemez ")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stok Adedi Boş Geçilemez ")]
        public uint? Stock { get; set; }

        [Required(ErrorMessage = "Ürün Resmi  Boş Geçilemez ")]
        public string ImageUrl { get; set; }
        public bool? variousProduct { get; set; }
        public string? SKU { get; set; }

        [Required(ErrorMessage = "Ürün Durumu  Boş Geçilemez ")]
        public bool Status { get; set; }

        public bool Featured { get; set; }
        public string? Tags { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }


    }


}

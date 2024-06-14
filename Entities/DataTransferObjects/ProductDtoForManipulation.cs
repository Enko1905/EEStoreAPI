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
        [Required(ErrorMessage ="Ürün Adı Boş Geçilemez ")]
        [MinLength(2 ,ErrorMessage ="Minumum 2 Karakter Olmalı")]
        [MaxLength(100,ErrorMessage ="Maxsimum 100 Karakter Olmalı")]
        public string ProductName { get; set; }
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Açıklama  Boş Geçilemez ")]
        public String Description { get; set; }

        [Required(ErrorMessage = "Fiyat Boş Geçilemez ")]
        [Range(0,10000000)]
        public Decimal Price { get; set; }

        [Required(ErrorMessage = "Stok Adedi Boş Geçilemez ")]
        public int Stok { get; set; }
        
    }


}

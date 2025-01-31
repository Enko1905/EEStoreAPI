﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class ProductVariants
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public string? SKU { get; set; }
        public Products Products { get; set; }

        [ForeignKey("Color")]
        public int? ColorId { get; set; }
        public Color? Color { get; set; }

        [ForeignKey("Size")]
        public int? SizeId { get; set; }
        public Size? Size { get; set; }
        
        [Required]
        public uint Stock { get; set;}  

    }

}

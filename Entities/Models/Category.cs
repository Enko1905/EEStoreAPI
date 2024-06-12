﻿using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    // Kategori tablosu
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(150)]
        public string MetaTitle { get; set; }

        [MaxLength(300)]
        public string MetaDescription { get; set; }
        public ICollection<Products> Products { get; set; }
    }

}
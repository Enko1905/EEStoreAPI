using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    // Alt Kategori tablosu
    public class SubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(150)]
        public string MetaTitle { get; set; }

        [MaxLength(300)]
        public string MetaDescription { get; set; }
        public ICollection<Products> Products { get; set; }
    }

}

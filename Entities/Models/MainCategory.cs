using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    // Ana Kategori tablosu
    public class MainCategory
    {
        [Key]
        public int MainCategoryId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(500)]
        public string MetaTitle { get; set; }
        [MaxLength(500)]
        public string MetaDescription { get; set; }
        public bool? MainCategoryStasus { get; set; } = true;
        public ICollection<Category> Category { get; set; }
    }

}

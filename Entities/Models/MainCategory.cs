using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    // Ana Kategori tablosu
    public class MainCategory
    {
        [Key]
        public int MainCategoryId { get; set; }

        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(150)]
        public string MetaTitle { get; set; }

        [MaxLength(300)]
        public string MetaDescription { get; set; }
        public ICollection<Category> Category { get; set; }
    }

}

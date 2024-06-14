using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    // Ana Kategori tablosu
    public class MainCategory
    {
        [Key]
        public int MainCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public ICollection<Category> Category { get; set; }
    }

}

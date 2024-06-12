using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class ProductCustomAttributes
    {
        [Key]
        public int ProductCustomId { get; set; }
        public string Name { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Products Products { get; set; }
    }

}

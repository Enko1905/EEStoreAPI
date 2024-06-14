using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        [MaxLength(100)]
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        [MaxLength(5000)]
        public string Description { get; set; }

        [ForeignKey("SubCategory")]
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }


        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<ProductAttribute> ProductAttributes { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<ProductCustomAttributes> productCustomAttributes { get; set; }
        public ICollection<ProductVariants> productVariants { get; set; }
    }
}

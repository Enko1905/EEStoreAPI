using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        // [Required(ErrorMessage ="kategori Adı Boş")]
        //[MaxLength(250, ErrorMessage = "kategori adı en fazla 100 karakter olabilir.")]
        [MaxLength]
        public string CategoyName { get; set; } = string.Empty;
        //public List<Products> Products { get; set; }
    }
}

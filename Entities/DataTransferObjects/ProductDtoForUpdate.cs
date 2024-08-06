using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Entities.DataTransferObjects
{
    public record ProductDtoForUpdate:ProductDtoForManipulation
    {
        public int Id { get; set; }
        public DateTime UpdateDate { get; set; }

        public ICollection<ProductImageDtoForUpdate>? ProductImages { get; set; }

        public ICollection<ProductAttributeDtoForUpdate>? ProductAttributes { get; set; }
        public ICollection<ProductVariantsDtoForUpdate>? productVariants { get; set; }

        public ProductDtoForUpdate()
        {
            UpdateDate = DateTime.UtcNow;
        }
    }

}

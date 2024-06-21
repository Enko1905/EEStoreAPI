﻿using Entities.Models;
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
        public int ProductId { get; set; }
        
        public ICollection<ProductImageDto>? ProductImages { get; set; }

        public ICollection<ProductAttributeDto>? ProductAttributes { get; set; }
        public ICollection<ProductVariantDto>? productVariants { get; set; }

    }

}

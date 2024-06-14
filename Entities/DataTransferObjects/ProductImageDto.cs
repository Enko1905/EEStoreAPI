using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record ProductImageDto
    {
        public int ProductImageId { get; set; }
        public string? ImageUrl { get; set; }
        public int ProductId { get; set; }
    }
}

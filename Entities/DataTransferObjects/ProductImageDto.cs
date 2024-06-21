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
        public int ProductImageId { get; init; }
        public string? ImageUrl { get; init; }
        public int ProductId { get; init; }
    }
    public abstract record ProductImageDtoForManipualtion
    {
        [MaxLength(800, ErrorMessage = "Resim Metin Uzunluğu En fazla 800 karakter olabilir")]
        public string? ImageUrl { get; set; }
        public int ProductId { get; set; }
    }

    public record ProductImageDtoForInsert : ProductImageDtoForManipualtion
    {
    }
    public record ProductImageDtoForUpdate 
    {
        public int ProductImageId { get; set; }

    }
}

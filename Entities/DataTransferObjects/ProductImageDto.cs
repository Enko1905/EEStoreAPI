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
        public int Id { get; init; }
        public string? ImageUrl { get; set; }
        public string? Alt { get; set; }
        public int ProductId { get; init; }
    }
    public abstract record ProductImageDtoForManipualtion
    {
        [MaxLength(300, ErrorMessage = "Resim Metin Uzunluğu En fazla 300 karakter olabilir")]
        public string? ImageUrl { get; set; }

        [MaxLength(300, ErrorMessage = "Resim Alt Uzunluğu En fazla 300 karakter olabilir")]
        public string? Alt { get; set; }


        [Required(ErrorMessage = "ProcuctImage tablosunda ProductId boş geçilemez")]
        public int ProductId { get; set; }
    }

    public record ProductImageDtoForInsert : ProductImageDtoForManipualtion
    {
    }
    public record ProductImageDtoForUpdate: ProductImageDtoForManipualtion
    {
        public int Id { get; set; }

    }
}

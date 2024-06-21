using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record ProductAttributeDto
    {
        public int ProductAttributeId { get; init; }
        public int ProductId { get; init; }
        public string Type { get; init; }
        public string Value { get; init; }
    }
    public record ProductAttributeDtoForInsert : ProductAttributeDtoForManipualtion
    {

    }
    public record ProductAttributeDtoForUpdate : ProductAttributeDtoForManipualtion
    {
        public int ProductAttributeId { get; set; }

    }

    public abstract record ProductAttributeDtoForManipualtion
    {

        [Required(ErrorMessage = "Product ID alanı gereklidir.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Type alanı gereklidir.")]
        [MaxLength(50, ErrorMessage = "Type alanı en fazla 50 karakter olabilir.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Value alanı gereklidir.")]
        [MaxLength(150, ErrorMessage = "Value alanı en fazla 150 karakter olabilir.")]
        public string Value { get; set; }
    }
}

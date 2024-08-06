using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record MainCategoryDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public string MetaTitle { get; init; }
        public string MetaDescription { get; init; }
        public bool Status { get; init; }

    }

    public record MainCategoryDtoInsertion : MainCategoryDtoManipulation
    {

    }

    public abstract record MainCategoryDtoManipulation
    {
        [Required(ErrorMessage = "Ad alanı gereklidir."), MaxLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Açıklama alanı gereklidir."),MaxLength(500, ErrorMessage = "Açıklama en fazla 300 karakter olabilir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Meta başlığı alanı gereklidir."),MaxLength(50, ErrorMessage = "Meta başlık en fazla 50 karakter olabilir.")]
        public string MetaTitle { get; set; }

        [Required(ErrorMessage = "Meta Açıklama  alanı gereklidir."),MaxLength(300, ErrorMessage = "Meta açıklama en fazla 300 karakter olabilir.")]
        public string MetaDescription { get; set; }
        public bool Status { get; set; }

    }

    public record MainCategoryDtoUpdate : MainCategoryDtoManipulation
    {
        public int Id { get; set; }
    }
}

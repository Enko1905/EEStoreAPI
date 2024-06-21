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
        public int MainCategoryId { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public bool MainCategoryStasus { get; init; }

        public string MetaTitle { get; init; }

        public string MetaDescription { get; init; }
    }

    public record MainCategoryDtoInsertion : MainCategoryDtoManipulation
    {

    }

    public abstract record MainCategoryDtoManipulation
    {
        [Required(ErrorMessage = "Ad alanı gereklidir."), MaxLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string Description { get; set; }

        [MaxLength(150, ErrorMessage = "Meta başlık en fazla 150 karakter olabilir.")]
        public string MetaTitle { get; set; }

        [MaxLength(300, ErrorMessage = "Meta açıklama en fazla 300 karakter olabilir.")]
        public string MetaDescription { get; set; }
        public bool? MainCategoryStasus { get; set; }

    }

    public record MainCategoryDtoUpdate : MainCategoryDtoManipulation
    {
        public int MainCategoryId { get; set; }
    }
}

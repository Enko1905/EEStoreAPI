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
    public record SubCategoryDto
    {

        public int Id { get; init; }
        public string Name { get; init; }
        public int CategoryId { get; init; }
        public string Description { get; init; }
        public string MetaTitle { get; init; }
        public string MetaDescription { get; init; }
        public bool Status { get; init; }

    }
    public abstract record SubCategoryDtoForManipulation
    {

        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        [MaxLength(100, ErrorMessage = "Ad en fazla 100 karakter olabilir.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category ID alanı gereklidir.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Açıklama alanı gereklidir."), MaxLength(300, ErrorMessage = "Açıklama en fazla 300 karakter olabilir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Meta başlığı alanı gereklidir."), MaxLength(50, ErrorMessage = "Meta başlık en fazla 50 karakter olabilir.")]
        public string MetaTitle { get; set; }

        [Required(ErrorMessage = "Meta Açıklama  alanı gereklidir."), MaxLength(300, ErrorMessage = "Meta açıklama en fazla 300 karakter olabilir.")]
        public string MetaDescription { get; set; }
        public bool Status { get; set; }
    }
    public record SubCategoryDtoForInsert :SubCategoryDtoForManipulation { 
    } 
    public record SubCategoryDtoForUpdate : SubCategoryDtoForManipulation
    {
        public int Id { get; set; }
    }
}

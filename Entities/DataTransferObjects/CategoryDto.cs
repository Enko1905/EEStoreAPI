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
    public record CategoryDto
    {
        public int Id { get; init; }

        public int MainCategoryId { get; init; }

        public string Name { get; init; }

        public string Description { get; init; }

        public string MetaTitle { get; init; }
        public bool Status { get; init; }

        public string MetaDescription { get; init; }

    }
    public record class CategoryDtoForInsertion : CategoryDtoForManipulation
    {

    }
    public abstract record CategoryDtoForManipulation
    {

        [Required(ErrorMessage = "Ana kategori ID'si gereklidir.")]
        public int MainCategoryId { get; set; }

        [Required(ErrorMessage = "Ad alanı gereklidir."), MaxLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Açıklama alanı gereklidir."), MaxLength(300, ErrorMessage = "Açıklama en fazla 300 karakter olabilir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Meta başlığı alanı gereklidir."), MaxLength(50, ErrorMessage = "Meta başlık en fazla 50 karakter olabilir.")]
        public string MetaTitle { get; set; }

        [Required(ErrorMessage = "Meta Açıklama  alanı gereklidir."), MaxLength(300, ErrorMessage = "Meta açıklama en fazla 300 karakter olabilir.")]
        public string MetaDescription { get; set; }
        public bool Status { get; set; }

    }
    public record CategoryDtoForUpdate : CategoryDtoForManipulation
    {
        public int Id { get; set; }

    }


}

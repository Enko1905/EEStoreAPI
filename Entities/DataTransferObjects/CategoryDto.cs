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
        public int CategoryId { get; init; }

        public int MainCategoryId { get; init; }

        public string Name { get; init; }

        public string Description { get; init; }

        public string MetaTitle { get; init; }

        public string MetaDescription { get; init; }

    }
    public record class CategoryDtoForInsertion : CategoryDtoForManipulation
    {

    }
    public abstract record CategoryDtoForManipulation
    {

        [Required(ErrorMessage = "Ana kategori ID'si gereklidir.")]
        public int MainCategoryId { get; set; }

        [Required(ErrorMessage = "Ad gereklidir."), MaxLength(100, ErrorMessage = "Ad en fazla 100 karakter olabilir.")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string Description { get; set; }

        [MaxLength(150, ErrorMessage = "Meta başlık en fazla 150 karakter olabilir.")]
        public string MetaTitle { get; set; }

        [MaxLength(300, ErrorMessage = "Meta açıklama en fazla 300 karakter olabilir.")]
        public string MetaDescription { get; set; }

    }
    public record CategoryDtoForUpdate : CategoryDtoForManipulation
    {
        public int CategoryId { get; set; }

    }


}

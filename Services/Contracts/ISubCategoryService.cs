using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ISubCategoryService
    {
        Task<IEnumerable<SubCategoryDto>> GetAllSubCategoryAsync(int id ,bool trachChanges);
        Task<SubCategoryDto> GetOneSubCategoryByIdAsync(int id, bool trackChanges);
        Task<SubCategoryDto> CreateOneSubCategoryAsync(SubCategoryDtoForInsert SubCategoryDto);
        Task UpdateOneSubCategoryAsync(int id, SubCategoryDtoForUpdate SubCategoryDto, bool trachChanges);
        Task DeleteOneSubCategoryAsync(int id, bool trackChanges);
    }
}

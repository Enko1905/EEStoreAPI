using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoryAsync(int id ,bool trachChanges);
        Task<CategoryDto> GetOneCategoryByIdAsync(int id, bool trackChanges);
        Task<CategoryDto> CreateOneCategoryAsync(CategoryDtoForInsertion Categorys);
        Task UpdateOneCategoryAsync(int id, CategoryDtoForUpdate CategorysDto);
        Task DeleteOneCategoryAsync(int id, bool trackChanges);
       
    }
}

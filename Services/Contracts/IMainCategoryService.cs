using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IMainCategoryService
    {
        Task<IEnumerable<MainCategoryDto>> GetAllMainCategoryAsync( bool trachChanges);
        Task<MainCategoryDto> GetOneMainCategoryByIdAsync(int id, bool trackChanges);
        Task<MainCategoryDto> CreateOneMainCategoryAsync(MainCategoryDtoInsertion MainCategoryDto);
        Task UpdateOneMainCategoryAsync(int id, MainCategoryDtoUpdate MainCategoryDto ,bool trachChanges);
        Task DeleteOneMainCategoryAsync(int id, bool trackChanges);
        Task<ICollection<MainCategory>> GetAllMainCategoryWithCategoryAndSubCategoryAsync(bool trackChanges);
    }
}

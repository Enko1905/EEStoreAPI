using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IMainCategoryRepository:IRepositoryBase<MainCategory>
    {
        Task<IEnumerable<MainCategory>> GetAllMainCategoryAsync(bool trackChanges);
        Task<MainCategory> GetOneMainCategoryByIdAync(int id, bool trackChanges);
        void CreateOneMainCategory(MainCategory mainCategory);
        void UpdateOneMainCategory(MainCategory mainCategory);
        void DeleteOneMainCategory(MainCategory mainCategory);
        Task<ICollection<MainCategory>> GetAllMainCategoryWithCategoryAndSubCategory(bool trackChanges);
    }
}

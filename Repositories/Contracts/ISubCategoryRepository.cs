using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ISubCategoryRepository:IRepositoryBase<SubCategory>
    {
        Task<IEnumerable<SubCategory>> GetAllSubCategoryAsync(int id, bool trackChanges);
        Task<SubCategory> GetOneSubCategoryByIdAync(int id, bool trackChanges);
        void CreateOneSubCategory(SubCategory SubCategory);
        void UpdateOneSubCategory(SubCategory SubCategory); 
        void DeleteOneSubCategory(SubCategory SubCategory);
    }
}

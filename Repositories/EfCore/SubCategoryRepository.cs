using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class SubCategoryRepository : RepositoryBase<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneSubCategory(SubCategory SubCategory) => Create(SubCategory);


        public void DeleteOneSubCategory(SubCategory SubCategory) => Delete(SubCategory);


        public async Task<IEnumerable<SubCategory>> GetAllSubCategoryAsync(int id, bool trackChanges)
        {
            return await FindAll(trackChanges).Where(x => x.CategoryId==id).ToListAsync();
        }

        public async Task<SubCategory> GetOneSubCategoryByIdAync(int id, bool trackChanges) =>
            await FindByCondition(x => x.Id==id, trackChanges).SingleOrDefaultAsync();

        public void UpdateOneSubCategory(SubCategory SubCategory)=>Update(SubCategory);
        
    }
}

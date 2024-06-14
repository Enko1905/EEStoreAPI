using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class MainCategoryRepository : RepositoryBase<MainCategory>, IMainCategoryRepository
    {
        public MainCategoryRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneMainCategory(MainCategory mainCategory) => Create(mainCategory);


        public void DeleteOneMainCategory(MainCategory mainCategory) => Delete(mainCategory);


        public async Task<IEnumerable<MainCategory>> GetAllMainCategoryAsync(bool trackChanges)
        {
            var entity = await FindAll(trackChanges).OrderByDescending(x => x.MainCategoryId).ToListAsync();
            return entity;
        }

        public async Task<ICollection<MainCategory>> GetAllMainCategoryWithCategoryAndSubCategory(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .Include(x => x.Category)
                .ThenInclude(s => s.SubCategories)
                .ToListAsync();
        }

        public async Task<MainCategory> GetOneMainCategoryByIdAync(int id, bool trackChanges)
        {
            return await FindByCondition(x => x.MainCategoryId==id, trackChanges).SingleOrDefaultAsync();
        }

        public void UpdateOneMainCategory(MainCategory mainCategory) => Update(mainCategory);

    }
}

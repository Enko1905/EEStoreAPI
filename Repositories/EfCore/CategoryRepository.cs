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
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {

        public CategoryRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneCategory(Category category) => Create(category);


        public void DeleteOneCategory(Category category) => Delete(category);

        public async Task<List<Category>> GetAllCategoryAsync(int id ,bool trackChanges) =>
           await FindAll(trackChanges).Where(x=>x.MainCategoryId.Equals(id)).OrderBy(x=>x.Id).ToListAsync();

        public async Task<Category> GetOneCategoryByIdAync(int id, bool trackChanges) =>

        await FindByCondition(x => x.Id==id, trackChanges).SingleOrDefaultAsync();

        public void UpdateOneCategory(Category category) => Update(category);

    }
}

﻿using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ICategoryRepository:IRepositoryBase<Category>
    {
        Task<List<Category>> GetAllCategoryAsync(int id ,bool trackChanges);
        Task<Category> GetOneCategoryByIdAync(int id, bool trackChanges);
        void CreateOneCategory(Category category);
        void UpdateOneCategory(Category category);
        void DeleteOneCategory(Category category);
    }
}

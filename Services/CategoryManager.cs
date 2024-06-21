using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
       private readonly IRepositoryManager _manager;
       private readonly IMapper _mapper;
        public CategoryManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _manager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<CategoryDto> CreateOneCategoryAsync(CategoryDtoForInsertion CategoryDto)
        {
            var entity = _mapper.Map<Category>(CategoryDto);

           
            _manager.Category.Create(entity);
            await _manager.SaveAsync();
            return _mapper.Map<CategoryDto>(entity);
        }

        public async Task DeleteOneCategoryAsync(int id, bool trackChanges)
        {
            var entity = await GetOneCategoryByIdAndCheckExists(id, false);
            _manager.Category.DeleteOneCategory(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoryAsync(int id, bool trachChanges)
        {
            var entity = await _manager.Category.GetAllCategoryAsync(id, trachChanges);
            var CategoryDto = _mapper.Map<IEnumerable<CategoryDto>>(entity);
            return CategoryDto;
        }

        public async Task<CategoryDto> GetOneCategoryByIdAsync(int id, bool trackChanges)
        {
            await GetOneCategoryByIdAndCheckExists(id, false);

            var entity = await _manager.Category.FindByCondition(x => x.CategoryId.Equals(id), trackChanges).SingleOrDefaultAsync();
            return _mapper.Map<CategoryDto>(entity);
        }

        public async Task UpdateOneCategoryAsync(int id, CategoryDtoForUpdate CategorysDto)
        {
            await GetOneCategoryByIdAndCheckExists(id, false);
            var entity = _mapper.Map<Category>(CategorysDto);
            _manager.Category.Update(entity);
            await _manager.SaveAsync();
        }

        public async Task<Category> GetOneCategoryByIdAndCheckExists(int id, bool trackChanges)
        {
            var entity = await _manager.Category.GetOneCategoryByIdAync(id, trackChanges);
            if (entity is null)
            {
                throw new CategoryNotFoundException(id);
            }
            return entity;
        }
    }
}

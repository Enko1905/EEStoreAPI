using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MainCategoryManager : IMainCategoryService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public MainCategoryManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _manager = repositoryManager;
        }

        public async Task<MainCategoryDto> CreateOneMainCategoryAsync(MainCategoryDtoInsertion MainCategoryDto)
        {
            var entity = _mapper.Map<MainCategory>(MainCategoryDto);
            _manager.MainCategory.Create(entity);
            await _manager.SaveAsync();
            return _mapper.Map<MainCategoryDto>(entity);
        }

        public async Task DeleteOneMainCategoryAsync(int id, bool trackChanges)
        {
            var entity = await GetOneMainCategoryByIdAndCheckExists(id, trackChanges);
            _manager.MainCategory.Delete(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<MainCategoryDto>> GetAllMainCategoryAsync(bool trachChanges)
        {
            var entity = await _manager.MainCategory.GetAllMainCategoryAsync(trachChanges);
            return _mapper.Map<IEnumerable<MainCategoryDto>>(entity);
        }

        public async Task<ICollection<MainCategory>> GetAllMainCategoryWithCategoryAndSubCategory(bool trackChanges)
        {
            var entity = await _manager.MainCategory.GetAllMainCategoryWithCategoryAndSubCategory(trackChanges);
            return entity;
        }

        public async Task<MainCategoryDto> GetOneMainCategoryByIdAsync(int id, bool trackChanges)
        {
            var entity = await _manager.MainCategory.GetOneMainCategoryByIdAync(id, trackChanges);
            return _mapper.Map<MainCategoryDto>(entity);
        }

        public async Task UpdateOneMainCategoryAsync(int id, MainCategoryDtoUpdate MainCategoryDto, bool trachChanges)
        {
            await GetOneMainCategoryByIdAndCheckExists(id, trachChanges);
            var category = _mapper.Map<MainCategory>(MainCategoryDto);
            _manager.MainCategory.Update(category);
            await _manager.SaveAsync();
        }
        public async Task<MainCategory> GetOneMainCategoryByIdAndCheckExists(int id, bool trackChanges)
        {
            var entity = await _manager.MainCategory.GetOneMainCategoryByIdAync(id, trackChanges);
            if (entity is null)
            {
                throw new MainCategoryNotFoundException(id);
            }
            return entity;
        }
    }
}

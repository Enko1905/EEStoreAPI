using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SubCategoryManager : ISubCategoryService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public SubCategoryManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<SubCategoryDto> CreateOneSubCategoryAsync(SubCategoryDtoForInsert SubCategoryDto)
        {
            var category = _mapper.Map<SubCategory>(SubCategoryDto);
            _manager.SubCategory.Create(category);
            await _manager.SaveAsync();
            return _mapper.Map<SubCategoryDto>(category);
        }

        public async Task DeleteOneSubCategoryAsync(int id, bool trackChanges)
        {
            var entity = await GetOneSubCategoryByIdAndCheckExists(id, trackChanges);
            _manager.SubCategory.Delete(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<SubCategoryDto>> GetAllSubCategoryAsync(int id, bool trachChanges)
        {
            var subCategory = await _manager.SubCategory.GetAllSubCategoryAsync(id, trachChanges);
            return _mapper.Map<IEnumerable<SubCategoryDto>>(subCategory);
        }

        public async Task<SubCategoryDto> GetOneSubCategoryByIdAsync(int id, bool trackChanges)
        {
            var subCategory = await _manager.SubCategory.GetOneSubCategoryByIdAync(id,trackChanges);
            return _mapper.Map<SubCategoryDto>(subCategory);
        }

        public async Task UpdateOneSubCategoryAsync(int id, SubCategoryDtoForUpdate SubCategoryDto, bool trachChanges)
        {
             await GetOneSubCategoryByIdAndCheckExists(id, trachChanges);
            var entity = _mapper.Map<SubCategory>(SubCategoryDto);
            _manager.SubCategory.Update(entity);
            await _manager.SaveAsync();
        }
        public async Task<SubCategory> GetOneSubCategoryByIdAndCheckExists(int id, bool trackChanges)
        {
            var entity = await _manager.SubCategory.GetOneSubCategoryByIdAync(id, trackChanges);
            if (entity is null)
            {
                throw new MainCategoryNotFoundException(id);
            }
            return entity;
        }
    }
}

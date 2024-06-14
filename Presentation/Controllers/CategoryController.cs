using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    // [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAllCategory(int id = 1)
        {
            var category = await _manager.CategoryService.GetAllCategoryAsync(id, false);
            return Ok(category);
        }

        [HttpGet("OneCategory/{id:int}")]
        public async Task<IActionResult> GetOneCategory([FromRoute(Name = "id")] int id)
        {
            var category = await _manager.CategoryService.GetOneCategoryByIdAsync(id, false);
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDtoForInsertion categoryDto)
        {
            await _manager.CategoryService.CreateOneCategoryAsync(categoryDto);
            return StatusCode(201,categoryDto);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCategory([FromRoute(Name ="id")] int id, [FromBody] CategoryDtoForUpdate categoryDto)
        {
            await _manager.CategoryService.UpdateOneCategoryAsync(id,categoryDto);
            return StatusCode(201, categoryDto);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategory([FromRoute(Name = "id")] int id)
        {
            await _manager.CategoryService.DeleteOneCategoryAsync(id,false);
            return StatusCode(201);
        }
    }
}

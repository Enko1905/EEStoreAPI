using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/subCategory")]
    public class SubCategoryController : ControllerBase
    {
        IServiceManager _manager;

        public SubCategoryController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAllSubCategory(int id = 1)
        {
            var category = await _manager.SubCategoryService.GetAllSubCategoryAsync(id, false);
            return Ok(category);
        }

        [HttpGet("OneSubCategory/{id:int}")]
        public async Task<IActionResult> GetOneSubCategory([FromRoute(Name = "id")] int id)
        {
            var category = await _manager.SubCategoryService.GetOneSubCategoryByIdAsync(id, false);
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSubCategory([FromBody] SubCategoryDtoForInsert subCategoryDto)
        {
            await _manager.SubCategoryService.CreateOneSubCategoryAsync(subCategoryDto);
            return StatusCode(201, subCategoryDto);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateSubCategory([FromRoute(Name = "id")] int id, [FromBody] SubCategoryDtoForUpdate subCategoryDto)
        {
            await _manager.SubCategoryService.UpdateOneSubCategoryAsync(id, subCategoryDto, false);
            return StatusCode(201, subCategoryDto);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSubCategory([FromRoute(Name = "id")] int id)
        {
            await _manager.SubCategoryService.DeleteOneSubCategoryAsync(id, false);
            return StatusCode(201);
        }
    }
}

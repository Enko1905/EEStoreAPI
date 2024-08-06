using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/mainCategory")]
    public class MainCategoryController:ControllerBase
    {
        private readonly IServiceManager _manger;

        public MainCategoryController(IServiceManager manger)
        {
            _manger = manger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMainCatregory()
        {
            var entity = await _manger.MainCategoryService.GetAllMainCategoryAsync(true);
            return Ok(entity);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneMainCatregory([FromRoute(Name = "id")] int id)
        {
            var entity = await _manger.MainCategoryService.GetOneMainCategoryByIdAsync(id,true);
            return Ok(entity);
        }
        [HttpGet("GetAllSubMainCatregory")]
        public async Task<IActionResult> GetAllSubMainCatregory()
        {
            var entity = await _manger.MainCategoryService.GetAllMainCategoryWithCategoryAndSubCategoryAsync(true);
            return Ok(entity);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMainCategory([FromBody] MainCategoryDtoInsertion mainCategoryDto)
        {
            var entity = await _manger.MainCategoryService.CreateOneMainCategoryAsync(mainCategoryDto);
            return Ok(entity);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMainCategory([FromRoute(Name = "id")] int id)
        {
             await _manger.MainCategoryService.DeleteOneMainCategoryAsync(id, false);
            return StatusCode(202);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMainCategory([FromRoute(Name ="id")] int id , [FromBody] MainCategoryDtoUpdate mainCategoryDto)
        {
            await _manger.MainCategoryService.UpdateOneMainCategoryAsync(id, mainCategoryDto,false);
            return StatusCode(201,mainCategoryDto);
        }

    }
}

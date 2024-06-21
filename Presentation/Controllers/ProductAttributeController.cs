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
    [Route("api/productAttribute")]
    public class ProductAttributeController:ControllerBase
    {
        private readonly IServiceManager _manager;

        public ProductAttributeController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProdutAttribute([FromBody] ProductAttributeDtoForInsert productAttributeDto)
        {
            await _manager.ProductAttributeService.CreateProductAttribute(productAttributeDto);
            return StatusCode(201,productAttributeDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProdutAttribute([FromRoute] int id, [FromBody] ProductAttributeDtoForUpdate productAttributeDto)
        {
            await _manager.ProductAttributeService.UpdateProductAttribute(id,productAttributeDto);
            return StatusCode(201, productAttributeDto);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProdutAttribute([FromRoute] int id)
        {
            await _manager.ProductAttributeService.DeleteProductAttribute(id);
            return StatusCode(201);
        }
    }
}

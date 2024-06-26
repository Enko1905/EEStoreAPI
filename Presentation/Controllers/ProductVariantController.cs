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
    [Route("api/productVariant")]
    public class ProductVariantController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ProductVariantController(IServiceManager manager)
        {
            _manager = manager;
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneProductVariants([FromRoute] int id)
        {
            var entity = await _manager.ProductVariantService.GetOneProductVariantsSkuCodeAync(id, false);
            return Ok(entity);
        }
        [HttpGet("sku/{skuCode}")]
        public async Task<IActionResult> GetAllProductVariantsSkuCode([FromRoute] int id)
        {
            var entity = await _manager.ProductVariantService.GetAllProductVariantsSkuCodeAsync(id, false);
            return Ok(entity);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductVariant([FromBody] ProductVariantsDtoForInsert productDto)
        {
            await _manager.ProductVariantService.CreateOneProductVariantsAsync(productDto);
            return StatusCode(201,productDto);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProductVariant([FromRoute] int id)
        {
            await _manager.ProductVariantService.DeleteOneProductVariantsAsync(id,false);
            return NoContent();
        }
    }
}

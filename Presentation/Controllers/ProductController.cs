using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
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
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProductAsync()
        {
            var result = await _manager.ProductService.GetAllProductAsync(false);
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneProductAsync([FromRoute(Name = "id")] int id)
        {
            var book = await _manager.ProductService.GetOneProductByIdAsync(id, false);
            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOneProductAsync([FromBody] ProductDtoForInsertion productsDto)
        {
            if (productsDto is null)
            {
                return BadRequest(); //404
            }
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            await _manager.ProductService.CreateOneProductAsync(productsDto);
            return StatusCode(201, productsDto); //CreatedAtRoute() 

        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneProductAsync([FromRoute(Name = "id")] int id, [FromBody] ProductDtoForUpdate productsDto)
        {

            var entity = await _manager.ProductService.GetOneProductByIdAsync(id, false);
            if (entity is null)
            {
                return NotFound(); //404 not found
            }
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            await _manager.ProductService.UpdateOneProductAsync(id, productsDto);
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneProductAsync([FromRoute] int id)
        {
            await _manager.ProductService.DeleteOneProductAsync(id, false);
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PartiallyUpdateOneProductAsync([FromRoute(Name = "id")] int id,
            [FromBody] JsonPatchDocument<ProductDtoForUpdate> productPatch)
        {
            if (productPatch is null)
            {
                return BadRequest(); //400
            }
            var result = await _manager.ProductService.GetOneProductForPatchAsync(id, false);
            productPatch.ApplyTo(result.productDtoForUpdate, ModelState);
            TryValidateModel(result.productDtoForUpdate);
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            await _manager.ProductService.SaveChangesForPatchAsync(result.productDtoForUpdate, result.products);
            return NoContent(); //204 
        }

    }
}

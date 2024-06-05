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
        public IActionResult GetAllProduct()
        {
            var result = _manager.ProductService.GetAllProduct(false);
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneProduct([FromRoute(Name = "id")] int id)
        {

            var book = _manager.ProductService.GetOneProductById(id, false);

            return Ok(book);

        }
        [HttpPost]
        public IActionResult CreateOneProduct([FromBody] ProductDtoForInsertion productsDto)
        {

            if (productsDto is null)
            {
                return BadRequest(); //404
            }
            _manager.ProductService.CreateOneProduct(productsDto);
            return StatusCode(201, productsDto); //CreatedAtRoute() 

        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateOneProduct([FromRoute(Name = "id")] int id, [FromBody] ProductDtoForUpdate productsDto)
        {

            var entity = _manager.ProductService.GetOneProductById(id, false);
            if (entity is null)
            {
                return NotFound(); //404 not found
            }
            if (id != productsDto.Id)
            {
                return BadRequest(); //400 bad request eşleşmedi
            }
            _manager.ProductService.UpdateOneProduct(id, productsDto);
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneProduct([FromRoute] int id)
        {
            _manager.ProductService.DeleteOneProduct(id, false);
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneProduct([FromRoute(Name = "id")] int id,
            [FromBody] JsonPatchDocument<ProductDto> productPatch)
        {
            var productDto = _manager.ProductService.GetOneProductById(id, false);

            productPatch.ApplyTo(productDto);
            _manager.ProductService.UpdateOneProduct(id,
                new ProductDtoForUpdate()
                {
                    Id = productDto.Id,
                    ProductName = productDto.ProductName,
                    CategoryId = productDto.CategoryId,
                    Description = productDto.Description,
                    Price = productDto.Price,
                    Stok = productDto.Stok
                });

            return NoContent();
        }

    }
}

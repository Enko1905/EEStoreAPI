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
            try
            {
                var book = _manager.ProductService.GetOneProductById(id, false);
                if (book is null)
                {
                    return NotFound(); //404
                }
                return Ok(book);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateOneProduct([FromBody] Products products)
        {
            try
            {
                if (products is null)
                {
                    return BadRequest(); //404
                }
                _manager.ProductService.CreateOneProduct(products);
                return StatusCode(201, products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateOneProduct([FromRoute(Name = "id")] int id, [FromBody] Products products)
        {
            try
            {
                var entity = _manager.ProductService.GetOneProductById(id, false);
                if (entity is null)
                {
                    return NotFound(); //404 not found
                }
                if (id != products.Id)
                {
                    return BadRequest(); //400 bad request eşleşmedi
                }
                _manager.ProductService.UpdateOneProduct(id, products);
                return StatusCode(201, products);
            }
            catch (Exception ex)
            {

                //return BadRequest(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneProduct([FromRoute] int id)
        {
            try
            {
                var entity = _manager.ProductService.GetOneProductById(id, false);
                if (entity is null)
                {
                    return NotFound();
                }
                _manager.ProductService.DeleteOneProduct(id, false);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneProduct([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Products> productPatch)
        {
            try
            {
                var entity = _manager.ProductService.GetOneProductById(id, false);
                if (entity is null)
                {
                    return NotFound(); //404
                }
                productPatch.ApplyTo(entity);
                _manager.ProductService.UpdateOneProduct(id, entity);
                return NoContent();//204
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

    }
}

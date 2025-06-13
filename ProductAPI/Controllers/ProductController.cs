using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        [Route("Products")]
        public IActionResult GetProducts()
        {
            List<Product> products = productService.ListProduct();
            return Ok(products);
        }
        [HttpGet]
        [Route("Products/{id}")]
        public IActionResult GetProduct(int id) { 
            Product product = productService.GetProductById(id);
            return Ok(product);
        }
        [HttpPut]
        [Route("Products/Update/{id}")]
        public IActionResult UpdateProduct(Product product) { 
            Product updatedProduct = productService.UpdateProduct(product);
            if (updatedProduct != null) { 
                
                return Ok(updatedProduct);
            }
            else return BadRequest();
        }
        [HttpDelete]
        [Route("Products/Delete/{id}")]
        public IActionResult DeleteProduct(int id) {
            Product productDeleted = productService.GetProductById(id);
            if (productDeleted != null) {
                productService.DeleteProduct(id);
                return Ok();
            }
            else return NotFound();
        }
        [HttpPost]
        [Route("Products/Create")]
        public IActionResult CreateProduct(Product product) { 
            Product createdProduct = productService.CreateProduct(product);
            if (createdProduct != null) {
               return Ok(createdProduct);
            }else return BadRequest();
        }
    }
}

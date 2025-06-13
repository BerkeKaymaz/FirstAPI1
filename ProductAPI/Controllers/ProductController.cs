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
            Product product_samp = productService.UpdateProduct(product);
            if (product_samp != null) { 
                Product product_upd = productService.UpdateProduct(product);
                return Ok(product_upd);
            }
            else return BadRequest();
        }
        [HttpDelete]
        [Route("Products/Delete/{id}")]
        public IActionResult DeleteProduct(int id) {
            Product product_samp = productService.GetProductById(id);
            if (product_samp != null) {
                productService.DeleteProduct(id);
                return Ok();
            }
            else return NotFound();
        }
        [HttpPost]
        [Route("Products/C")]
        public IActionResult CreateProduct(Product product) { 
            Product cre_product = productService.CreateProduct(product);
            if (cre_product != null) {
               return Ok(cre_product);
            }else return BadRequest();
        }
    }
}

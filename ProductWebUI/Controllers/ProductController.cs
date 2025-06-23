using Application.Interfaces;
using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ProductWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IProductRepository productRepository;

        public ProductController(IProductService productService, IProductRepository productRepository)
        {
            this.productService = productService;
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = productService.ListProduct();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product) { 
            if (ModelState.IsValid)
            {
                productService.CreateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        public IActionResult Edit(int id) { 
            var product = productService.GetProductById(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product) {
            if (ModelState.IsValid)
            {
                productService.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Delete(int id) {
            productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }

    }
}

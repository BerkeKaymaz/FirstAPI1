using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;
using Domain.Repositories;
using Infrastructure.Contexts;

namespace Application.Services
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        private readonly IProductRepository productRepository = productRepository;

        public Product CreateProduct(Product product)
        {
           return productRepository.CreateProduct(product);
        }

        public void DeleteProduct(int id)
        {
            productRepository.DeleteProduct(id);
        }

        public Product GetProductById(int id)
        {
            return productRepository.GetProductById(id);
        }

        public List<Product> ListProduct()
        {
            return productRepository.ListProduct();
        }

        public Product UpdateProduct(Product product)
        {
            return productRepository.UpdateProduct(product);
        }
    }
}

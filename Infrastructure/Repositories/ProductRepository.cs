using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Repositories;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private MySQLContext context;
        public ProductRepository(MySQLContext context)
        {
            this.context = context;
        }
        public Product CreateProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        public void DeleteProduct(int id)
        {
            Product product = GetProductById(id);
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public Product GetProductById(int id)
        {
            return context.Products.Find(id);
        }

        public List<Product> ListProduct()
        {
            return context.Products.ToList();
        }

        public Product UpdateProduct(Product product)
        {
            context.Products.Update(product); 
            context.SaveChanges();
            return product;
        }
    }
}

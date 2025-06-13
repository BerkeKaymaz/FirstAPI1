using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IProductService
    {
        List<Product> ListProduct();

        Product UpdateProduct(Product product);
        Product CreateProduct(Product product);
        Product GetProductById(int id);
        void DeleteProduct(int id);    



    }
}

using FitnessFoods.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessFoods.Core.Services
{
    public interface IProductServices
    {
        List<Product> GetProducts(int NumeroItens, int PageNumber);
        Product GetProduct(string code);
        Product AddProduct(Product product);
        Product UpdateProduct(Product product);
        Product DeleteProduct(string code);
  
    }
}

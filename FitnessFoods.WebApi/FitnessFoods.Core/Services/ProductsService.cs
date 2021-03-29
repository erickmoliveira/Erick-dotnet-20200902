using FitnessFoods.Core.Entidades;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace FitnessFoods.Core.Services
{
    public class ProductsService : IProductServices
    {
        private readonly IMongoCollection<Product> _products;
        public ProductsService(IDbClient dbClient)
        {
            _products = dbClient.GetProductsColletion();
        }

        public Product AddProduct(Product product)
        {
            _products.InsertOne(product);
            return product;
        }

        public List<Product> GetProducts(int NumeroItens, int PageNumber)
        {
            var products = _products.Find(product => true).SortByDescending(c => c.Imported_t).Skip(NumeroItens * PageNumber).Limit(NumeroItens).ToList();
       
        
            return products;
        }
        public Product GetProduct(string code)
        {

           var _product = _products.Find(p => p.Code == code).First();

        

            return _product;
            }

        public Product UpdateProduct(Product product)
        {
            GetProduct(product.Code);
            _products.ReplaceOne(p => p.Code == product.Code,product);

            return product;
        }

        public Product DeleteProduct(string code)
        {
         var product =   GetProduct(code);

            if (product == null)
                return null;

            product.Status = StatusEnum.trash;

            _products.ReplaceOne(p => p.Code == product.Code, product);

            return product;
        }
    }
}

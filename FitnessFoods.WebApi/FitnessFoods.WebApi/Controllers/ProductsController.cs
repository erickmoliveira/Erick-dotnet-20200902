using FitnessFoods.Core;
using FitnessFoods.Core.Entidades;
using FitnessFoods.Core.Services;
using FitnessFoods.Core.ViewModel;
using FitnessFoods.WebApi.Filter;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessFoods.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiKeyAuth]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductsController(IProductServices bookservices)
        {
            _productServices = bookservices;
        }

        [HttpGet("GetProducts/{PageSize}/{PageNumber}")]
        public IActionResult GetProducts(int PageSize, int PageNumber)
        {
            var products = _productServices.GetProducts(PageSize, PageNumber);

            if (products == null)
                return null;

            ProductList model = new ProductList();
            model.Page_Number = PageNumber;
            model.Page_Size = PageSize;

            foreach (var item in products)
            {
                ProductDataBase pd = new ProductDataBase();
                pd.Id = item.Code;
                pd.Creator = item.Creator;
                pd.Image_Url = item.Image_Url;
                pd.Status = item.Status.ToString();
                if (model.Items == null)
                    model.Items = new List<ProductDataBase>();
                model.Items.Add(pd);
            }


         
            return Ok(model.ToJson());
        }


        [HttpGet("GetAllProducts/{PageSize}/{PageNumber}")]
        public IActionResult GetAllProducts(int PageSize, int PageNumber)
        {
            var products = _productServices.GetProducts(PageSize, PageNumber);

            if (products == null)
                return null;

            ProductListViewModel model = new ProductListViewModel();
            model.Page_Number = PageNumber;
            model.Page_Size = PageSize;
            model.Items = products;
          



            return Ok(model.ToJson());
        }
        [HttpGet("{code}",Name ="GetProduct")]
        public IActionResult GetProduct(string code)
        {
           
            return Ok(_productServices.GetProduct(code).ToJson());
        }

        [HttpPost]
        public IActionResult AddProduct( Product product)
        {
            _productServices.AddProduct(product);
            return CreatedAtRoute("GetProduct", new {code=product.Code },product);
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            return Ok(_productServices.UpdateProduct(product).ToJson());
        }
        [HttpDelete("{code}", Name = "DeleteProduct")]
        public IActionResult DeleteProduct(string code )
        {
            return Ok(_productServices.DeleteProduct(code).ToJson());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessFoods.Tests.Routes
{
    public class ApiRoutes
    {
        private static readonly string _baseUrl = "https://localhost:5001/";

        public static class Products
        {
            private static readonly string _productsControllerUrl = string.Concat(_baseUrl, "Products");

            public static readonly string GetAll = _productsControllerUrl + "/GetAllProducts/100/0";

            public static readonly string Get = string.Concat(_productsControllerUrl, "/0000000000017");

            public static readonly string Delete = string.Concat(_productsControllerUrl, "/0000000000017");
            public static readonly string PostProduct = _productsControllerUrl;
        }
    }
}

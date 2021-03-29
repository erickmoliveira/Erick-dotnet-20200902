using FitnessFoods.Core;
using FitnessFoods.Core.Entidades;
using FitnessFoods.Tests.Routes;
using FluentAssertions;
using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FitnessFoods.Tests
{
    public class IntegrationTests : IntegrationTest
    {
        [Fact]
        public async Task GetAll_Products()
        {
            // Arrange
            await AuthenticateAsync();

            // Act
            var response = await TestClient.GetAsync(ApiRoutes.Products.GetAll);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
          
        }


        [Fact]
        public async Task Get_Product()
        {
            // Arrange
            await AuthenticateAsync();

            // Act
            var response = await TestClient.GetAsync(ApiRoutes.Products.Get);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }


        [Fact]
        public async Task PUT_Product()
        {
            // Arrange
            await AuthenticateAsync();


        

            Product prod = new Product();
            prod.Code = "0000000000017";
            prod.Created_t = DateTime.Now.ToString();
            prod.Creator = "Erick";
            prod.Imported_t= DateTime.Now;
            prod.Status =(StatusEnum)2;
            string output = JsonConvert.SerializeObject(prod);

            var content = new StringContent(output.Replace(@"""Status"":""published""", @"""Status"":2"), Encoding.UTF8, "application/json"); ;
            // Act
            var response = await TestClient.PutAsync(ApiRoutes.Products.PostProduct, content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }
    }
}

using FitnessFoods.WebApi;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FitnessFoods.Tests
{
    public class IntegrationTest
    {

        protected readonly HttpClient TestClient;

        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            TestClient = appFactory.CreateClient();

            TestClient = appFactory.CreateClient();
        }
        protected async Task AuthenticateAsync()
        {
            TestClient.DefaultRequestHeaders.Add("apikey", "MYTESTAPIKEY");
        }
    }
}
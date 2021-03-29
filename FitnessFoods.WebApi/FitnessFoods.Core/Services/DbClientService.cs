

using FitnessFoods.Core.Entidades;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FitnessFoods.Core.Services
{
    public class DbClientService : IDbClient
    {
        private readonly IMongoCollection<Product> _products;
        private readonly IMongoCollection<CronImportations> _cron;
        public DbClientService(IOptions<FitnessFoodsDbConfig> fitnessfoodsDbConfig)
        {
            if (fitnessfoodsDbConfig.Value.Database_Name == null)
            {
                fitnessfoodsDbConfig.Value.Database_Name = "ProductsDb";
            }
            if (fitnessfoodsDbConfig.Value.Products_Collection_Name == null)
            {
                fitnessfoodsDbConfig.Value.Products_Collection_Name = "Products";
            }
            if (fitnessfoodsDbConfig.Value.CronImportations_Collection_Name == null)
            {
                fitnessfoodsDbConfig.Value.CronImportations_Collection_Name = "Cron";
            }
            var cliente = new MongoClient(fitnessfoodsDbConfig.Value.Connection_String);
            var database = cliente.GetDatabase(fitnessfoodsDbConfig.Value.Database_Name);

            _products = database.GetCollection<Product>(fitnessfoodsDbConfig.Value.Products_Collection_Name);
            _cron = database.GetCollection<CronImportations>(fitnessfoodsDbConfig.Value.CronImportations_Collection_Name);

        }

        public IMongoCollection<CronImportations> GetCronColletion()
        {
            return _cron;
        }

        public IMongoCollection<Product> GetProductsColletion()
        {
            return _products;
        }
    }
}

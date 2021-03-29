using FitnessFoods.Core.Entidades;
using MongoDB.Driver;

namespace FitnessFoods.Core.Services
{
    public interface IDbClient
    {
        IMongoCollection<Product> GetProductsColletion();
        IMongoCollection<CronImportations> GetCronColletion();
    }
}

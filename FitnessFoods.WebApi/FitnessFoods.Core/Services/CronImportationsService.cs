using FitnessFoods.Core.Entidades;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FitnessFoods.Core.Services
{
    public class CronImportationsService : ICronImportationsService
    {

        private readonly IMongoCollection<CronImportations> _cron;
     
        public CronImportationsService(IDbClient dbClient)
        {
            _cron = dbClient.GetCronColletion();
          
        }
        public CronImportations AddCron(CronImportations cron)
        {
            _cron.InsertOne(cron);
            return cron;
        }

        public CronImportations GetStatusCron()
        {
            var lastCron = _cron.Find(cron => true).SortByDescending(c => c.id).FirstOrDefault();

            return lastCron;
        }
    }
}

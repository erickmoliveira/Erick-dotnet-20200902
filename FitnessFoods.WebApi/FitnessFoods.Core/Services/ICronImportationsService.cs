using FitnessFoods.Core.Entidades;

namespace FitnessFoods.Core.Services
{
    public interface ICronImportationsService
    {
        CronImportations AddCron(CronImportations cron);
        CronImportations GetStatusCron();
    }
}
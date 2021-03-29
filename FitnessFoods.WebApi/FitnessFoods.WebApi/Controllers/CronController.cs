using FitnessFoods.Core;
using FitnessFoods.Core.Services;
using FitnessFoods.WebApi.Filter;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessFoods.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiKeyAuth]
    public class CronController : ControllerBase
    {
        private readonly ICronImportationsService _cronServices;

        public CronController(ICronImportationsService cronServices)
        {
            _cronServices = cronServices;
        }

        [HttpGet]
        public IActionResult GetStatus()
        {
            var Cron = _cronServices.GetStatusCron();
            Cron.ImportDateTime = DateTime.Parse(Cron.ImportDateTime.ToString("dd/MM/yyyy HH:mm"));
            Cron.ImportTime = TimeSpan.FromMilliseconds(int.Parse(Cron.ImportTime)).TotalMinutes.ToString("F");
            string json = JsonConvert.SerializeObject(Cron);
            
            return Ok(json);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessFoods.Core.Entidades
{
    public class FitnessFoodsDbConfig
    {
        public string Database_Name { get; set; }

        public string Products_Collection_Name { get; set; }
        public string Connection_String { get; set; }
        public string CronImportations_Collection_Name { get; set; }
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessFoods.Core.Entidades
{
    public class CronImportations
    {

        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public DateTime ImportDateTime { get; set; }
        public int NumberofObjects { get; set; }
        public string ImportTime { get; set; }
    }
}

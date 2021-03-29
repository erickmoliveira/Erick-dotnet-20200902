using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace FitnessFoods.Core.Entidades
{
    public class Product
    {
        [BsonId]
        public string Code { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]  // JSON.Net
        [BsonRepresentation(BsonType.String)]
        public StatusEnum Status { get; set; }
        public DateTime? Imported_t { get; set; }
        public string Url { get; set; }
        public string Creator { get; set; }
        public string Created_t { get; set; }
        public string Last_modified_t { get; set; }
        public string Product_Name { get; set; }
        public string Quantity { get; set; }
        public string Brands { get; set; }
        public string Categories { get; set; }
        public string Labels { get; set; }
        public string Cities { get; set; }
        public string Purchase_Places { get; set; }
        public string Stores { get; set; }
        public string Ingredients_Text { get; set; }
        public string Traces { get; set; }
        public string Serving_size { get; set; }
        public Decimal? Serving_Quantity { get; set; }
        public int? Nutriscore_Score { get; set; }
        public string Nutriscore_Grade { get; set; }
        public string Main_Category { get; set; }
        public string Image_Url { get; set; }


    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StatusEnum
    {
  
        draft ,
        trash ,
        published
    };
}

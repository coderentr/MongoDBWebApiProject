using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBWebApiProject.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("brand")]
        public string Brand { get; set; }
        [BsonElement("category")]
        public string Category { get; set; }
        [BsonElement("price")]
        public decimal Price { get; set; }
    }
}

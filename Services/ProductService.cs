using MongoDB.Driver;
using MongoDBWebApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBWebApiProject.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> _products;
        public ProductService(IDemoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _products = database.GetCollection<Product>(settings.ProductCollectionName);
        }
        public List<Product> GetList()
        {
            var data= _products.Find(p => true).ToList();
            return data;
        }
        public Product Get(string id)
        {
            return _products.Find<Product>(p => p.Id == id).FirstOrDefault();
        }
        public Product Create(Product product)
        {
            _products.InsertOne(product);
            return product;
        }
        public void Update(Product product) 
        {
            _products.ReplaceOne(p => p.Id == product.Id, product);
        }
        public void Delete(string id)
        {
            _products.DeleteOne(book => book.Id == id);
        }
    }
}

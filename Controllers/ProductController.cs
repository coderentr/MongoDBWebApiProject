using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDBWebApiProject.Models;
using MongoDBWebApiProject.Services;

namespace MongoDBWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [Route("GetProductList")]
        public ActionResult<List<Product>> ProductList()
        {
            return _productService.GetList();
        }
        [HttpGet]
        [Route("GetProduct")]
        public ActionResult<Product> GetProduct(string Id)
        {
            return _productService.Get(Id);
        }
        [HttpPost]
        [Route("CreateProduct")]
        public ActionResult<Product> CreateProduct(Product product)
        {
            _productService.Create(product);
            return Ok(product);
        }
        [HttpPut]
        [Route("UpdateProduct")]
        public ActionResult<Product> UpdateProduct(Product product)
        {
            var result = _productService.Get(product.Id);
            result.Name = product.Name;
            result.Price = product.Price;
            result.Brand = product.Brand;
            result.Category = product.Category;
            _productService.Update(result);
            return Ok(product);
        }
        [HttpDelete]
        [Route("DeleteProduct")]
        public IActionResult Delete(string id)
        {
            var prod = _productService.Get(id);

            if (prod == null)
            {
                return NotFound();
            }
            _productService.Delete(prod.Id);
            return Ok();
        }
    }
}

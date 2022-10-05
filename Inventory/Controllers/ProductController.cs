using System.Collections.Generic;
using Inventory.Models;
using Inventory.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase   
    {
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetAll();
            
        }
        [HttpGet("{id}")]
        public Product GetById(int id)
        {
           return ProductService.Get(id);
        }

        [HttpPost]
        public void Post(Product product)
        {
            ProductService.Add(product);
        }
        [HttpPut]
        public void Put(Product product)
        {
            ProductService.Update(product);
        }
        [HttpDelete("{id}")] 
        public void Delete(int id )
        {
            ProductService.Delete(id);
        }
    }
}

using System.Collections.Generic;
using Inventory.Models;
using Inventory.Services;
using Inventory.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase   
    {
        IProductService _productService;
        public ProductController (IProductService productService)
        {
            _productService = productService;
        }
        // get retornoa lista de todos produtos 
        [HttpGet]
        public IEnumerable<Product> Get() => _productService.GetAll();


        // get com id, retorna um produto especifico 
        [HttpGet("{id}")]
        public Product GetById(int id) => _productService.Get(id);
        
        // criar um novo produto
        [HttpPost]
        public void Post(Product product) => _productService.Add(product);
       
        // put adiciona um produto novo, como o update retorno um product, basta colocar o nome do produto
        [HttpPut]
        public void Put(Product product) => _productService.Update(product);
      
        // delte deleta o produto pelo id, basta apenas colocar o id do produto que quer o deletar
        [HttpDelete("{id}")] 
        public void Delete(int id ) => _productService.Delete(id);
      
    }
}

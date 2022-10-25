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
        /// <summary>
        /// list all products
        /// </summary>
        /// <returns> Ok </returns>
        [HttpGet]
        public IEnumerable<Product> Get() => _productService.GetAll();
        // get com id, retorna um produto especifico 
        /// <summary>
        /// get a product by its id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Ok</returns>
        [HttpGet("{id}")]
        public Product GetById(int id) => _productService.Get(id);
        
        // criar um novo produto
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Created</returns>
        [HttpPost]
        public void Post(Product product) => _productService.Add(product);
       
        // put adiciona um produto novo, como o update retorno um product, basta colocar o nome do produto
        /// <summary>
        /// create a new product 
        /// </summary>
        /// <param name="product"></param>
        /// <returns>No content</returns>
        [HttpPut]
        public void Put(Product product) => _productService.Update(product);
      
        // delte deleta o produto pelo id, basta apenas colocar o id do produto que quer o deletar
        /// <summary>
        /// delete product by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No Content</returns>
        [HttpDelete("{id}")] 
        public void Delete(int id ) => _productService.Delete(id);
      
    }
}

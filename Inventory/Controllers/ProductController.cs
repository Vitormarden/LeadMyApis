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
        public IActionResult GetById(int id) 
        { 
            Product verificaProduto = _productService.Get(id);
            if (verificaProduto == null)
            {
                return NotFound();
            }
            return Ok(verificaProduto);
        }
        
        // criar um novo produto
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Created</returns>
        [HttpPost]
        public IActionResult Post(Product product)
        {
            bool verificaAdd = _productService.Add(product);
            if(verificaAdd == true)
            {
                return Created("", product);

            }
            return BadRequest();
        }
        // put adiciona um produto novo, como o update retorno um product, basta colocar o nome do produto
        /// <summary>
        /// create a new product 
        /// </summary>
        /// <param name="product"></param>
        /// <returns>No content</returns>
        [HttpPut]
        public IActionResult Put(Product product)
        {
            bool verificaUpdate = _productService.Update(product);
            if(verificaUpdate == true)
            {
                return NoContent();
            }
            return BadRequest(verificaUpdate);
        }
      
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

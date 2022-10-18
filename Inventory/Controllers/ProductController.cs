﻿using System.Collections.Generic;
using Inventory.Models;
using Inventory.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase   
    {
        // get retornoa lista de todos produtos 
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            ProductService service = new ProductService();
            return service.GetAll();
        }
        
        // get com id, retorna um produto especifico 
        [HttpGet("{id}")]
        public Product GetById(int id)
        {
           ProductService service = new ProductService();
           return service.Get(id);
        }
        // criar um novo produto
        [HttpPost]
        public void Post(Product product)
        {
            ProductService service = new ProductService();
             service.Add(product);
        }
        // put adiciona um produto novo, como o update retorno um product, basta colocar o nome do produto
        [HttpPut]
        public void Put(Product product)
        {
            ProductService service = new ProductService();
            service.Update(product);
        }
        // delte deleta o produto pelo id, basta apenas colocar o id do produto que quer o deletar
        [HttpDelete("{id}")] 
        public void Delete(int id )
        {
            ProductService service =new ProductService();
             service.Delete(id);
        }
    }
}

using Inventory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Services
{
    public static class ProductService
    {
        static List<Product> Products { get; }
        static int nextId = 3;
        static ProductService()
        {
            // Criando os primeiros produtos, por meio de uma lista
            Products = new List<Product>
            {
                new Product { Id = 1, Name = "bola" },
                new Product { Id = 2, Name = "chuteira" }
            };
        }
        // getall vai receber products 
        public static List<Product> GetAll() => Products;
        public static Product? Get(int id) => Products.FirstOrDefault(p => p.Id == id);
      //add vai recever um product, o id do product vai ser defido pelo id passado mais 1
        public static void Add(Product product)
        {
            product.Id = nextId++;
            Products.Add(product);
        }
        // o delete vai receber 1 inteiro, no caso vou escolher o id do produto , diferente disso ele nã oretorna nada
        public static void Delete(int id)
        {
            var product = Get(id);
            if (product is null)
                return;
            Products.Remove(product);
        }
        public static void Update(Product product)
        {
            var index = Products.FindIndex(p => p.Id == product.Id);
            if (index == -1)
                return;
            Products[index] = product;
        }
    }
}



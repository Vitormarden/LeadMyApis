using Inventory.Data;
using Inventory.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Services
{
    public  class ProductService
    {
      
        public ProductService()
        {
            
        }
        // getall vai receber products 
        public  List<Product> GetAll()
        {
            Context _context = new Context();
            return  _context.Product.ToList();
        }
        public  Product? Get(int id) 
        {
            Context _context = new Context();
            return _context.Product.FirstOrDefault(p => p.Id_Product == id); 
        }
            //add vai recever um product, o id do product vai ser defido pelo id passado mais 1
            public  void Add(Product product)
        {
            Context _context = new Context();
            _context.Product.Add(product);
        }
        // o delete vai receber 1 inteiro, no caso vou escolher o id do produto , diferente disso ele nã oretorna nada
        public void Delete(int id)
        {
            Context _context = new Context();
            var product = Get(id);
            if (product is null)
                return;
            _context.Remove(product);
        }
        public void Update(Product product)
        {
            Context _context = new Context();
            _context.Product.Update(product);
        }
    
    }
}



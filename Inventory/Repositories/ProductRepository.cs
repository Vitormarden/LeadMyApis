using System.Collections.Generic;
using System.Linq;
using Inventory.Data;
using Inventory.Models;
using Inventory.Repositories.Interfaces;
using Inventory.Services;

namespace Inventory.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private Context _context;
        public ProductRepository( Context context)
        {
            _context = context;

        }
        public List<Product> GetAll()
        {
            return _context.Product.ToList();
        }
        public Product? Get(int id)
        {
            return _context.Product.FirstOrDefault(p => p.Id_Product == id);
        }
        public void Add(Product product)
        {
            _context.Product.Add(product);
        }
        public void Delete(Product produtoDeletar)
        {
            
            _context.Remove(produtoDeletar);
            _context.SaveChanges();
        }
        public void Update(Product product)
        {
            _context.Product.Update(product);
        }
    }
}

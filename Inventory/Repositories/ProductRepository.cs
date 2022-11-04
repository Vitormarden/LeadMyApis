using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Data;
using Inventory.Models;
using Inventory.Repositories.Interfaces;
using Inventory.Services;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private Context _context;
        public ProductRepository( Context context)
        {
            _context = context;

        }
        public async Task<List<Product>> GetAll()
        {
            return await _context.Product.ToListAsync();
        }
        public async Task<Product?> Get(int id)
        {
            return await _context.Product.FirstOrDefaultAsync(p => p.Id_Product == id);
        }
        public async Task Add(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
        }
        public async Task  Delete(Product produtoDeletar)
        {
            
            _context.Remove(produtoDeletar);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Product product)
        {
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}

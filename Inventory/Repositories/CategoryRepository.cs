using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Data;
using Inventory.Models;
using Inventory.Repositories.Interfaces;
using Inventory.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private Context _context;
        public CategoryRepository(Context context)
        {
            _context = context;
        }
      
        // getall vai receber products 
        public async Task<List<Category>> GetAll()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category?> Get(int id)
        {
             return await _context.Category.FirstOrDefaultAsync(p => p.Id_Category == id);
        }
        //=> Category.FirstOrDefault(p => p.Id == id);
        //add vai recever um product, o id do product vai ser defido pelo id passado mais 1
        public async Task Add(Category category)
        {
            _context.Category.Add(category);                      //category.Id = nextId++;
            await _context.SaveChangesAsync();                                                     //Category.Add(category);
        }
        // o delete vai receber 1 inteiro, no caso vou escolher o id do produto , diferente disso ele nã oretorna nada
        public async Task Delete(Category categoryDelete)
        {
            _context.Category.Remove(categoryDelete);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Category category)
        {
            _context.Category.Update(category);
            await _context.SaveChangesAsync();


        }
    }
}
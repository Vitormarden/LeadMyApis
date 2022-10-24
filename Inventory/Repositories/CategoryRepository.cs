using System.Collections.Generic;
using System.Linq;
using Inventory.Data;
using Inventory.Models;
using Inventory.Repositories.Interfaces;
using Inventory.Services.Interface;

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
        public List<Category> GetAll()
        {
            return _context.Category.ToList();
        }

        public Category? Get(int id)
        {
            return _context.Category.FirstOrDefault(p => p.Id_Category == id);
        }
        //=> Category.FirstOrDefault(p => p.Id == id);
        //add vai recever um product, o id do product vai ser defido pelo id passado mais 1
        public void Add(Category category)
        {
            _context.Category.Add(category);                      //category.Id = nextId++;
            _context.SaveChanges();                                                     //Category.Add(category);
        }
        // o delete vai receber 1 inteiro, no caso vou escolher o id do produto , diferente disso ele nã oretorna nada
        public void Delete(Category categoryDelete)
        {

         
            _context.Category.Remove(categoryDelete);
            _context.SaveChanges();
        }
        public void Update(Category category)
        {
            _context.Category.Update(category);
            _context.SaveChanges();


        }
    }
}
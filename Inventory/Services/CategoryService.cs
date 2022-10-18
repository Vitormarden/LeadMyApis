using Inventory.Data;
using Inventory.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Services
{
    public class CategoryService
    {


        public CategoryService()
        {

        }
        // getall vai receber products 
        public List<Category> GetAll()
        {
            Context _context = new Context();
            return _context.Category.ToList();
        }

        public Category? Get(int id)
        {
            Context _context = new Context();
            return _context.Category.FirstOrDefault(p => p.Id_Category == id);
        }
        //=> Category.FirstOrDefault(p => p.Id == id);
        //add vai recever um product, o id do product vai ser defido pelo id passado mais 1
        public void Post(Category category)
        {
            Context _context = new Context();
            _context.Category.Add(category);                      //category.Id = nextId++;
            _context.SaveChanges();                                                     //Category.Add(category);
        }
        // o delete vai receber 1 inteiro, no caso vou escolher o id do produto , diferente disso ele nã oretorna nada
        public void Delete(int id)
        {
            Context _context = new Context();

            var category = Get(id);
            if (category is null)
                return;
            _context.Remove(category);
            _context.SaveChanges();
        }
        public void Update(Category category)
        {
            Context _context = new Context();
            _context.Category.Update(category);
            _context.SaveChanges();


        }
    }
}


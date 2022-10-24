using Inventory.Data;
using Inventory.Models;
using Inventory.Repositories.Interfaces;
using Inventory.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Services
{
    public class CategoryService : ICategoryService
    {

        ICategoryRepository _categoryRepository ;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }


        // getall vai receber products 
        public List<Category> GetAll() => _categoryRepository.GetAll();
        
        public Category? Get(int id) => _categoryRepository.Get(id);
       
        //=> Category.FirstOrDefault(p => p.Id == id);
        //add vai recever um product, o id do product vai ser defido pelo id passado mais 1
        public void Add(Category category) => _categoryRepository.Add(category);
        
        // o delete vai receber 1 inteiro, no caso vou escolher o id do produto , diferente disso ele nã oretorna nada
        public void Delete(int id)
        {
            var categoryDeletar = _categoryRepository.Get(id);
            if (categoryDeletar != null)
                _categoryRepository.Delete(categoryDeletar);
        }
           
       
        public void Update(Category category)
        {
            if (category != null)
                _categoryRepository.Update(category);
        }
       
    }
}

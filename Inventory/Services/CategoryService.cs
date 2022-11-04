using Inventory.Data;
using Inventory.Models;
using Inventory.Repositories.Interfaces;
using Inventory.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<List<Category>> GetAll() => await _categoryRepository.GetAll();
        
        public async Task<Category?> Get(int id) => await _categoryRepository.Get(id);
       
        //=> Category.FirstOrDefault(p => p.Id == id);
        //add vai recever um product, o id do product vai ser defido pelo id passado mais 1
        public async Task<bool> Add(Category category)
        { 
            Category verificaIdCategory = await Get(category.Id_Category);
            if(verificaIdCategory == null) 
            { 
                await _categoryRepository.Add(category); 
                return true;
            }
            return false;
        }
        
        // o delete vai receber 1 inteiro, no caso vou escolher o id do produto , diferente disso ele nã oretorna nada
        public async Task Delete(int id)
        {
            var categoryDeletar = await _categoryRepository.Get(id);
            if (categoryDeletar != null)
                await _categoryRepository.Delete(categoryDeletar);
        }
           
       
        public async Task<bool> Update(Category category)
        {
            Category categoryById = await _categoryRepository.Get(category.Id_Category);
            if(categoryById != null)
            {
                await _categoryRepository.Add(category);
                return true;
            }
            return false;
        }
       
    }
}

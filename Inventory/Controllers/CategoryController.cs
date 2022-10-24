using System.Collections.Generic;
using System.Threading.Tasks;
using Inventory.Models;
using Inventory.Services;
using Inventory.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet]
        public List<Category> Get() => _categoryService.GetAll();


        [HttpGet("{id}")]
        public Category GetById(int id) => _categoryService.Get(id);
       
        [HttpPost]
        public void Post(Category category) => _categoryService.Add(category);
        
        [HttpDelete("{id}")] 
        public void Delete(int id) => _categoryService.Delete(id);

        [HttpPut]
        public void Put(Category category) => _categoryService.Update(category);
       




    }
}

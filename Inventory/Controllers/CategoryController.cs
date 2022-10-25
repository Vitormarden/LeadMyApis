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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Category> Get() => _categoryService.GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Category GetById(int id) => _categoryService.Get(id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        [HttpPost]
        public void Post(Category category) => _categoryService.Add(category);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No Content</returns>
        [HttpDelete("{id}")] 
        public void Delete(int id) => _categoryService.Delete(id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns>No Content</returns>
        [HttpPut]
        public void Put(Category category) => _categoryService.Update(category);
       




    }
}

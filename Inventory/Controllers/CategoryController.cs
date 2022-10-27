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
        public IActionResult GetById(int id)
        {
            Category verificaCategory = _categoryService.Get(id);
            if(verificaCategory == null)
            {
                return NotFound();
            }
            return Ok(verificaCategory);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        [HttpPost]
        public IActionResult Post(Category category) 
        {
            bool verificaAdd = _categoryService.Add(category);
            if(verificaAdd == true)
            {
                return Created("",category);
            }
            return BadRequest();
        }
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
        public IActionResult Put(Category category)
        {
            bool VerificaUpdate = _categoryService.Update(category);
            if(VerificaUpdate == true)
            {
                return NoContent();
            }
            return BadRequest(VerificaUpdate);
        }




    }
}

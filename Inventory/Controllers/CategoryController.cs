using System.Collections.Generic;
using Inventory.Models;
using Inventory.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public List<Category> Get()
        {
            return CategoryService.GetAll();
        }

        [HttpGet("{id}")]
        public Category GetById(int id)
        {
            return CategoryService.Get(id);
        }
        [HttpPost]
        public void Post(Category category)
        {
            CategoryService.Update(category);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CategoryService.Delete(id);
        }




    }
}

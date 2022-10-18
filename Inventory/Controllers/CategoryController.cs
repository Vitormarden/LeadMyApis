using System.Collections.Generic;
using System.Threading.Tasks;
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
            CategoryService service = new CategoryService();
            return service.GetAll();
        }

        [HttpGet("{id}")]
        public Category GetById(int id)
        {
            CategoryService service = new CategoryService();
            return service.Get(id);
        }
        [HttpPost]
        public void Post(Category category)
        {
            CategoryService service = new CategoryService();
            service.Post(category);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CategoryService service = new CategoryService();
             service.Delete(id);
        }




    }
}

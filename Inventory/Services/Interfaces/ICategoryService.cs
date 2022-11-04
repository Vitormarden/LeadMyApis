using Inventory.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Services.Interface
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();

        Task<Category?> Get(int id);

        Task<bool> Add (Category category);

        Task Delete(int id);

        Task<bool> Update(Category category);
 

    }
}

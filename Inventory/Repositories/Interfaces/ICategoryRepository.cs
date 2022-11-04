using System.Collections.Generic;
using System.Threading.Tasks;
using Inventory.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Inventory.Repositories.Interfaces
{
    public interface ICategoryRepository 
    {
        Task<List<Category>> GetAll();
        Task<Category?> Get(int id);

        Task Add(Category category);
        
        Task Update(Category category);
        Task Delete(Category categoryDeletar);
    }


}

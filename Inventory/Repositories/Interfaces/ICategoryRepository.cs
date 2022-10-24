using System.Collections.Generic;
using Inventory.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Inventory.Repositories.Interfaces
{
    public interface ICategoryRepository 
    {
        List<Category> GetAll();
        Category? Get(int id);

        void Add(Category category);
        
        void Update(Category category);
        void Delete(Category categoryDeletar);
    }


}

using Inventory.Models;
using System.Collections.Generic;

namespace Inventory.Services.Interface
{
    public interface ICategoryService
    {
        List<Category> GetAll();

        Category? Get(int id);

        void Add(Category category);

        void Delete(int id);

        void Update(Category category);


    }
}

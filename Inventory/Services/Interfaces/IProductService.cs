using Inventory.Models;
using System.Collections.Generic;

namespace Inventory.Services.Interface
{
    public interface IProductService
    {
        List<Product> GetAll();

        Product? Get(int id);

        bool Add(Product product);

        void Delete(int id);

        bool Update(Product product);

    }
}

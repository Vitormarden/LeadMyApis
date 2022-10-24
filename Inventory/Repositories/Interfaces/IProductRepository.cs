using Inventory.Models;
using System.Collections.Generic;

namespace Inventory.Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product? Get(int id);

        void Add(Product product);

        void Update(Product product);
        void Delete(Product produtoDeletar);
    }
}

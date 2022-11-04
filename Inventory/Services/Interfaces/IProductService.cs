using Inventory.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Services.Interface
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();

        Task<Product?> Get(int id);

        Task<bool> Add(Product product);

        Task Delete(int id);

        Task<bool> Update(Product product);

    }
}

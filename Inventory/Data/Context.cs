using Inventory.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Data
{
    public class Context : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder
        )
        {
            object value = optionsBuilder.UseSqlServer("Data Source=MARDONHA-NOT;Initial Catalog=Inventory;Integrated Security=True");
        }
    }
}

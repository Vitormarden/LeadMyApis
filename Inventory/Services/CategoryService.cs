using Inventory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Services
{
    public static class CategoryService
    {  
        static List<Category> Category { get; }
        static int nextId = 3;
        static CategoryService()
        {
            // Criando os primeiros produtos, por meio de uma lista
            Category = new List<Category>
            {
                new Category { Id = 1, Name = "esporte" },
                new Category { Id = 2, Name = "leitura" }
            };
        }
        // getall vai receber products 
        public static List<Category> GetAll() => Category;
        public static Category? Get(int id) => Category.FirstOrDefault(p => p.Id == id);
        //add vai recever um product, o id do product vai ser defido pelo id passado mais 1
        public static void Add(Category category)
        {
            category.Id = nextId++;
            Category.Add(category);
        }
        // o delete vai receber 1 inteiro, no caso vou escolher o id do produto , diferente disso ele nã oretorna nada
        public static void Delete(int id)
        {
            var category= Get(id);
            if (category is null)
                return;
            Category.Remove(category);
        }
        public static void Update(Category category)
        {
            var index = Category.FindIndex(p => p.Id == category.Id);
            if (index == -1)
                return;
            Category[index] = category;
        }
    }
}


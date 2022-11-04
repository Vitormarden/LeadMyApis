using Inventory.Data;
using Inventory.Models;
using Inventory.Repositories;
using Inventory.Repositories.Interfaces;
using Inventory.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Services
{
    public  class ProductService : IProductService
    {
        IProductRepository _productRepository;
        ICategoryRepository _categoryRepository;
        public ProductService(IProductRepository  productRepository, ICategoryRepository categoryRepository )
        {
            this._productRepository = productRepository;
            this._categoryRepository = categoryRepository;
        }
        // getall vai receber products 
        public  async Task<List<Product>> GetAll() => await _productRepository.GetAll();
      
        public async Task<Product?> Get(int id) => await _productRepository.Get(id);

        //add vai recever um product, o id do product vai ser defido pelo id passado mais 1
        public async Task<bool> Add(Product product) 
        {

            Product productById = await Get(product.Id_Product);
            Category categoryById = await _categoryRepository.Get(product.Id_Category);
            if (productById == null && categoryById != null) 
            {
                await _productRepository.Add(product);
                return true;
            }
            return false;

        }
        // o delete vai receber 1 inteiro, no caso vou escolher o id do produto , diferente disso ele nã oretorna nada
        public async Task Delete(int id)
        {
            var produtoDeletar = await _productRepository.Get(id);
            if(produtoDeletar != null)
                await _productRepository.Delete(produtoDeletar);
        }
     
        public async Task<bool> Update(Product product)
        {
            Product productByID = await _productRepository.Get(product.Id_Product);
            Category categoryById = await _categoryRepository.Get(product.Id_Category);
            if(productByID != null && categoryById != null)
            {
                await _productRepository.Update(product);
                return true;
            }
            return false;
           

        }
    
    
    }
}



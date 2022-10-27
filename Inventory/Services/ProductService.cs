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
        public  List<Product> GetAll() => _productRepository.GetAll();
      
        public  Product? Get(int id) => _productRepository.Get(id);

        //add vai recever um product, o id do product vai ser defido pelo id passado mais 1
        public bool Add(Product product) 
        {

            Product productById = Get(product.Id_Product);
            Category categoryById = _categoryRepository.Get(product.Id_Category);
            if (productById == null && categoryById != null) 
            {
                _productRepository.Add(product);
                return true;
            }
            return false;

            

        }
        // o delete vai receber 1 inteiro, no caso vou escolher o id do produto , diferente disso ele nã oretorna nada
        public void Delete(int id)
        {
            var produtoDeletar = _productRepository.Get(id);
            if(produtoDeletar != null)
                _productRepository.Delete(produtoDeletar);
        }
     
        public bool Update(Product product)
        {
            Product productByID = _productRepository.Get(product.Id_Product);
            Category categoryById = _categoryRepository.Get(product.Id_Category);
            if(productByID != null && categoryById != null)
            {
                _productRepository.Update(product);
                return true;
            }
            return false;
           

        }
    
    
    }
}



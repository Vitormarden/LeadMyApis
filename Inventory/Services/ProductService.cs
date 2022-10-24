using Inventory.Data;
using Inventory.Models;
using Inventory.Repositories.Interfaces;
using Inventory.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Services
{
    public  class ProductService : IProductService
    {
        IProductRepository _productRepository;
        public ProductService(IProductRepository  productRepository )
        {
            this._productRepository = productRepository;
        }
        // getall vai receber products 
        public  List<Product> GetAll() => _productRepository.GetAll();
      
        public  Product? Get(int id) => _productRepository.Get(id);
       
            //add vai recever um product, o id do product vai ser defido pelo id passado mais 1
        public  void Add(Product product) => _productRepository.Add(product);

        // o delete vai receber 1 inteiro, no caso vou escolher o id do produto , diferente disso ele nã oretorna nada
        public void Delete(int id)
        {
            var produtoDeletar = _productRepository.Get(id);
            if(produtoDeletar != null)
                _productRepository.Delete(produtoDeletar);
        }
     
        public void Update(Product product)
        {
            if(product != null)
                _productRepository.Update(product);
        }
    
    
    }
}



﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Inventory.Models;
using Inventory.Services;
using Inventory.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult  Get()
        {
            List<Category> categories =_categoryService.GetAll(); 
            return Ok(categories);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id <=0)
                return BadRequest("Id passado não pode ser menor que 0");
                
            Category verificaCategory = _categoryService.Get(id);
            if(verificaCategory == null)
            {
                return NotFound();
            }
            return Ok(verificaCategory);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        [HttpPost]
        public IActionResult Post(Category category) 
        {
            bool verificaAdd = _categoryService.Add(category);
            if(verificaAdd == true)
            {
                return Created("",category);
            }
            return BadRequest();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No Content</returns>
        [HttpDelete("{id}")] 
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            _categoryService.Delete(id);
            return NoContent();
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns>No Content</returns>
        [HttpPut]
        public IActionResult Put(Category category)
        {
            bool VerificaUpdate = _categoryService.Update(category);
            if(VerificaUpdate == true)
            {
                return NoContent();
            }
            return BadRequest(VerificaUpdate);
        }




    }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using BLayer.Implementations;
using Domain.Models;
using BLayer.Interfaces;
using System.Net.Http;
using System.Net;
using System;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller //System.Web.Http.ApiController
    {
        private ICategoryService _categoryService { get; set; }
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Category
        //[HttpGet]
        public IEnumerable<Category> Get()
        {
            return _categoryService.Get();
        }

        //GET: api/categories/1
        [HttpGet("{id}", Name = "GetCategory")]
        public IActionResult Get(int id)
        {
            var category = _categoryService.Get(id);

            if (category != null)
                return new ObjectResult(category);
            else
                return NotFound("Категория с ID:" + id.ToString() + " не найдена.");
        }

        //POST: api/Category
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            try
            {
                _categoryService.Add(category);
                return CreatedAtRoute("GetCategory", new { id = category.ID }, category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            try
            {
                _categoryService.Update(id, category);
                return new NoContentResult();  //Ok();
            }
            catch (Exception ex)
            {
                if (ex.Message == ("Категория с ID:" + id.ToString() + " не найдена."))
                    return NotFound(ex.Message);
                else
                    return BadRequest(ex.ToString());
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                _categoryService.Delete(id);
                return new NoContentResult();  //Ok();
            }
            catch (Exception ex)
            {
                if (ex.Message == ("Категория с ID:" + id.ToString() + " не найдена."))
                    return NotFound(ex.Message);
                else
                    return BadRequest(ex.ToString());
            }
        }
    }
}

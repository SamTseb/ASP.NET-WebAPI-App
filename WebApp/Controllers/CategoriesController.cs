using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
using BLayer.Implementations;
using System.Web.Http;
using Domain.Models;
using BLayer.Interfaces;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : ApiController
    {
        private ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Category
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_categoryService.Get());
        }

        // GET: api/Category/5
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IHttpActionResult Get(int id)
        {
            var category = _categoryService.Get(id);
            if (category != null)
                return Ok();
            else
                return NotFound();
        }

        // POST: api/Category
        [HttpPost]
        public IHttpActionResult Post([FromBody] Category category)
        {
            try
            {
                _categoryService.Add(category);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        // PUT: api/Category/5
        [HttpPut]
        [Route("api/[controller]/{id}")] // +[action] ?
        public IHttpActionResult Put(int id, [FromBody] Category category)
        {
            try
            {
                _categoryService.Update(category);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("api/[controller]/{id}")] // +[action] ?
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _categoryService.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}

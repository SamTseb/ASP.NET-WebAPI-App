using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using System.Web.Http;
using BLayer.Implementations;
using Domain.Models;
using BLayer.Interfaces;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class CarsController : ApiController
    {
        private ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: api/Car
        //[HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_carService.Get());
        }

        // GET: api/Car/5
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IHttpActionResult Get(int id)
        {
            var car = _carService.Get(id);
            if (car != null)
                return Ok();
            else
                return NotFound();
        }

        // POST: api/Car
        [HttpPost]
        public IHttpActionResult Post([FromBody] Car car)
        {
            try
            {
                _carService.Add(car);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        // PUT: api/Car/5
        [HttpPut]
        [Route("api/[controller]/{id}")] // +[action] ?
        public IHttpActionResult Put(int id, [FromBody] Car car)
        {
            try
            {
                _carService.Update(id, car);
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
                _carService.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}

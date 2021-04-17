//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using BLayer.Implementations;
using Domain.Models;
using BLayer.Interfaces;
using System.Net.Http;
using System.Net;
using System;
//using System.Web.Http;

namespace WebApp.Controllers
{
    //[ApiController]
    [Route("api/[controller]")]
    public class CarsController : Controller //System.Web.Http.ApiController
    {
        private ICarService _carService { get; set; }
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: api/Car
        //[HttpGet]
        public IEnumerable<Car> Get()
        {
            return _carService.Get();
        }

        //GET: api/cars/1
        [HttpGet("{id}", Name = "GetCar")]
        public IActionResult Get(int id)
        {
            var car = _carService.Get(id);
            
            if (car != null)
                return new ObjectResult(car);
            else
                return NotFound("Машина с ID:" + id.ToString() + " не найдена.");
        }

        //POST: api/Car
        [HttpPost]
        public IActionResult Post([FromBody] Car car)
        {
            try
            {
                _carService.Add(car);
                return CreatedAtRoute("GetCar", new { id = car.ID }, car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        // PUT: api/Car/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Car car)
        {
            try
            {
                _carService.Update(id, car);
                return new NoContentResult();  //Ok();
            }
            catch (Exception ex)
            {
                if (ex.Message == ("Машина с ID:" + id.ToString() + " не найдена."))
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
                _carService.Delete(id);
                return new NoContentResult();  //Ok();
            }
            catch (Exception ex)
            {
                if (ex.Message == ("Машина с ID:" + id.ToString() + " не найдена."))
                    return NotFound(ex.Message);
                else
                    return BadRequest(ex.ToString());
            }
        }
    }
}

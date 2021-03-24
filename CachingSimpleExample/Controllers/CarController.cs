namespace CachingSimpleExample.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CachingSimpleExample.CacheRepositories.Abstractions;
    using CachingSimpleExample.Models;
    using Microsoft.AspNetCore.Mvc;

    public class CarController : ControllerBase
    {
        private readonly ICarRepository<string, Car> carRepository;

        public CarController(ICarRepository<string, Car> carRepository)
        {
            this.carRepository = carRepository;
        }

        [HttpGet]
        [Route("/v1.0/cars")]
        public IActionResult GetBooks()
        {
            var result = this.carRepository.GetAllExistingCar();

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("/v1.0/car")]
        public IActionResult GetBook([FromQuery] string reference)
        {
            var result = this.carRepository.GetExistingCar(reference);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("/v1.0/createcar")]
        public IActionResult PostBook([FromBody] Car modelcar)
        {
            var car = MapCar(modelcar);
            var result = this.carRepository.InsertOrUpdateExistingCar(car);

            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("/v1.0/removecar")]
        public IActionResult DeleteBook([FromQuery] string reference)
        {
            var result = this.carRepository.RemoveExistingCar(reference);

            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        private Car MapCar(Car modelCar)
        {
            return new Car
            {
                Reference = modelCar.Reference,
                Model = modelCar.Model,
                Year = modelCar.Year,
            };
        }
    }
}

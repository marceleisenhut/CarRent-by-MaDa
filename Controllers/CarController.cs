using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarRent.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        Verzeichnis vz = new Verzeichnis();

        [HttpGet("[action]")]
        public IEnumerable<Car> Index()
        {
            return vz.GetAllCars();
        }


        [HttpPost("[action]")]
        [Route("api/Car/Create")]
        public void Create([FromBody] Car car)
        {
            vz.addCar(car);
        }

        [HttpGet("{id}")]
        [Route("api/Car/Details/{id}")]
        public Car Details(String id)
        {
            return vz.getCar(id);
        }

        [HttpPut]
        [Route("api/Car/Edit")]
        public void Edit([FromBody]Car Car)
        {
            vz.updateCar(Car);
        }

        [HttpDelete("{id}")]
        [Route("api/Car/Delete/{id}")]
        public void Delete(String id)
        {
            vz.deleteCar(id);
        }
    }
}

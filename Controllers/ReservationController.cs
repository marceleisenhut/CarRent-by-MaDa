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
    public class ReservationController : Controller
    {
        Verzeichnis vz = new Verzeichnis();

        [HttpGet("[action]")]
        public IEnumerable<Reservation> Index()
        {
            return vz.GetAllReservationen();
        }


        [HttpPost("[action]")]
        [Route("api/Reservation/Create")]
        public void Create([FromBody] Reservation Reservation)
        {
            vz.addReservation(Reservation);
        }

        [HttpGet("{id}")]
        [Route("api/Reservation/Details/{id}")]
        public Reservation Details(int id)
        {
            return vz.getReservation(id);
        }

        [HttpPut]
        [Route("api/Reservation/Edit")]
        public void Edit([FromBody]Reservation Reservation)
        {
            vz.updateReservation(Reservation);
        }

        [HttpDelete("{id}")]
        [Route("api/Reservation/Delete/{id}")]
        public void Delete(int id)
        {
            vz.deleteReservation(id);
        }
    }
}

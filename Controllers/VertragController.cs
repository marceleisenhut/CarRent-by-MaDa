﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarRent.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    public class VertragController : Controller
    {
        Verzeichnis vz = new Verzeichnis();

        [HttpGet("[action]")]
        public IEnumerable<Reservation> Index()
        {
            return vz.GetAllVertrage();
        }


        [HttpPost("[action]")]
        [Route("api/Vertrag/Create")]
        public void Create([FromBody] Reservation Vertrag)
        {
            vz.addVertrag(Vertrag);
        }

        [HttpGet("{id}")]
        [Route("api/Vertrag/Details/{id}")]
        public Reservation Details(int id)
        {
            return vz.getReservation(id);
        }

        [HttpPut]
        [Route("api/Vertrag/Edit")]
        public void Edit([FromBody]Reservation Vertrag)
        {
            vz.updateReservation(Vertrag);
        }

        [HttpDelete("{id}")]
        [Route("api/Vertrag/Delete/{id}")]
        public void Delete(int id)
        {
            vz.deleteReservation(id);
        }
    }
}

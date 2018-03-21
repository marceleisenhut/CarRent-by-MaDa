using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using CarRent.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        Verzeichnis vz = new Verzeichnis();

        [HttpGet("[action]")]
        public IEnumerable<Customer> Index()
        {
            return vz.GetAllCustomers();
        }

        
        [HttpPost("[action]")]
        [Route("api/Customer/Create")]
        public int Create([FromBody] Customer Customer)
        {
            vz.addKunde(Customer);
            return 1;
        }

        [HttpGet("{id}")]
        [Route("api/Customer/Details/{id}")]
        public Customer Details(int id)
        { 
            System.Console.WriteLine("Ausgabe Customer Details (Controller) ID: " + id);
            return vz.getCustomer(id);
        }

        [HttpPut]
        [Route("api/Customer/Edit")]
        public int Edit([FromBody]Customer Customer)
        {
            vz.updateKunde(Customer);
            return 1;
        }

        [HttpDelete("{id}")]
        [Route("api/Customer/Delete/{id}")]
        public int Delete(int id)
        {
            vz.deleteKunde(id);
            return 1;
        }
    }
}

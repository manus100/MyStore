using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStore.Domain.Entities;
using MyStore.Domain.Extensions;
using MyStore.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsService reportsService;

        public ReportsController(IReportsService reportsService)
        {
            this.reportsService = reportsService;
        }
        // GET: api/<ReportsController>
        [HttpGet]
        public ActionResult<List<Customer>> GetCustomersWithNoOrders()
        {
            return reportsService.GetCustomersWithNoOrders();
        }

        // GET: api/<ReportsController>
        [HttpGet("/contacts")]  
        //[HttpGet]
        //[Route("/contacts")]
        public ActionResult<List<CustomerContact>> GetCustomersContacts()
        {
            var contacts = reportsService.GetContacts();
            return contacts;
        }

        //cati customeri au comandat produsul cu id-ul x

         
        // GET api/<ReportsController>/5
        [HttpGet("{id}")]
        public CustomersOfAProduct Get(int id)
        {
            var result = reportsService.GetNbOfCustomers(id);
            return result;
        }

        // POST api/<ReportsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReportsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReportsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStore.Domain.Entities;
using MyStore.Models;
using MyStore.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        // GET: api/<CustomersController>
        [HttpGet]
        public IEnumerable<CustomerModel> Get()
        {
            return customerService.GetAll();
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public ActionResult<CustomerModel> Get(int id)
        {
            var result = customerService.GetByID(id);
            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerModel newCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var addedCustomer = customerService.AddCustomer(newCustomer);
            return CreatedAtAction("Get", new {id=addedCustomer.Custid}, addedCustomer);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public ActionResult<CustomerModel> Put(int id, [FromBody] CustomerModel customerToUpdate)
        {
            if (id!= customerToUpdate.Custid)
            {
                return BadRequest();
            }
            if (!customerService.Exists(id))
            {
                return NotFound();
            }

            var updatedCustomer = customerService.UpdateCustomer(customerToUpdate);
            // return NoContent();
            return Ok(updatedCustomer);
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!customerService.Exists(id))
            {
                return NotFound();
            }

            var isDeletetd = customerService.Delete(id);
            if (isDeletetd == false)
            {
                return UnprocessableEntity();
            }
            return NoContent();
        }
    }
}

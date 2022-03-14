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
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }
        // GET: api/<SuppliersController>
        [HttpGet]
        public IEnumerable<SupplierModel> Get()
        {
            return supplierService.GetAll();
        }

        // GET api/<SuppliersController>/5
        [HttpGet("{id}")]
        public ActionResult<SupplierModel> Get(int id)
        {
            var result = supplierService.GetByID(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST api/<SuppliersController>
        [HttpPost]
        public IActionResult Post([FromBody] SupplierModel newSupplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var addedSupplier = supplierService.Add(newSupplier);

            return CreatedAtAction("Get", new { id = addedSupplier.Supplierid }, addedSupplier);
        }

        // PUT api/<SuppliersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SupplierModel supplierToUpdate)
        {
            if (id!= supplierToUpdate.Supplierid)
            {
                return BadRequest();
            }

            if (!supplierService.Exists(id))
            {
                return NotFound();
            }

            supplierService.Update(supplierToUpdate);
            return NoContent();
        }

        // DELETE api/<SuppliersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!supplierService.Exists(id))
            {
                return NotFound();
            }

            var isDeletetd = supplierService.Delete(id);
            if (isDeletetd == false)
            {
                return UnprocessableEntity();
            }
            return NoContent();
        }
    }
}

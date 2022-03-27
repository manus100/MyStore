using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStore.Models;
using MyStore.Service;
using MyStore.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperService shipperService;

        public ShipperController(IShipperService shipperService)
        {
            this.shipperService = shipperService;
        }


        // GET: api/<ShipperController>
        [HttpGet]
        public IEnumerable<ShipperModel> Get()
        {
            return shipperService.GetAll();
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public ActionResult<ShipperModel> Get(int id)
        {
            var result = shipperService.GetByID(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST api/<ShipperController>
        [HttpPost]
        public IActionResult Post([FromBody] ShipperModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var addedShipper = shipperService.Add(model);

            return CreatedAtAction("Get", new { id = addedShipper.Shipperid }, addedShipper);
        }

        // PUT api/<ShipperController>/5
        [HttpPut("{id}")]
        public ActionResult<ShipperModel> Put(int id, [FromBody] ShipperModel model)
        {
            if (id != model.Shipperid)
            {
                return BadRequest();
            }

            if (!shipperService.Exists(id))
            {
                return NotFound();
            }

            var updatedShipper = shipperService.Update(model);
            // return NoContent();
            return Ok(updatedShipper);

        }

        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!shipperService.Exists(id))
            {
                return NotFound();
            }

            if (shipperService.HasOrders(id))
            {
                ModelState.AddModelError("ForeignKeyViolation", "This record can't be deleted, there are orders associated with this shipper!");

                return UnprocessableEntity(ModelState);
            }


            var IsDeleted = shipperService.Delete(id);
            if (IsDeleted == false)
                return UnprocessableEntity();
            else
                return NoContent();
        }
    }
}

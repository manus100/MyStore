using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Models;
using MyStore.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<EmployeeModel> Get()
        {
            return employeeService.GetAll();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public ActionResult<EmployeeModel> Get(int id)
        {
            var result = employeeService.GetByID(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var addedEmployee = employeeService.Add(model);

            return CreatedAtAction("Get", new { id = addedEmployee.Empid }, addedEmployee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ProductModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<EmployeeModel> Put(int id, [FromBody] EmployeeModel model)
        {
            if (id != model.Empid)
            {
                return BadRequest();
            }

            if (!employeeService.Exists(id))
            {
               // return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No employee found for this id");
               return NotFound();
            }

            var updatedEmployee = employeeService.Update(model);
            // return NoContent();
            return Ok(updatedEmployee);

        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!employeeService.Exists(id))
            {
                return NotFound();
            }

            if (employeeService.HasSubordinates(id))
            {
                ModelState.AddModelError("ForeignKeyViolation", "Can't delete this manager, it has subordinates!");

                return UnprocessableEntity(ModelState);
            }

            var IsDeleted = employeeService.Delete(id);
            //daca nu s-a sters return 422 status code
            if (IsDeleted == false)
                return UnprocessableEntity();
            else
                return NoContent();
        }
    }
}

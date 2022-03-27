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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }


        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<CategoryModel> GetAll()
        {
            return categoryService.GetAll();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public ActionResult<CategoryModel> Get(int id)
        {
            var result = categoryService.GetByID(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] CategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var addedCategory = categoryService.Add(model);

            return CreatedAtAction("Get", new { id = addedCategory.Categoryid }, addedCategory);
        }


        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public ActionResult<CategoryModel> Put(int id, [FromBody] CategoryModel model)
        {
            if (id != model.Categoryid)
                return BadRequest();

            if (!categoryService.Exists(id))
            {
                return NotFound();
            }

            var updatedCategory = categoryService.Update(model);
            return Ok(updatedCategory);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!categoryService.Exists(id))
                return NotFound();

            if (categoryService.HasProducts(id))
            {
                ModelState.AddModelError("ForeignKeyViolation", "This category can't be deleted, there are products associated with this category");

                return UnprocessableEntity(ModelState);
            }

            var IsDeleted = categoryService.Delete(id);
            if (IsDeleted == false)
                return UnprocessableEntity();
            else
                return NoContent();
            

        }
    }
}

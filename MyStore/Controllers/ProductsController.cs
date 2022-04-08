using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Domain.Entities;
using MyStore.Infrastructure.Attributes;
using MyStore.Models;
using MyStore.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProducService productService;

        public ProductsController(IProducService productService)
        {
            this.productService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        [ResponseHeader("AwesomeHeader", "From Web API Filter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ProductModel>> Get()
        {
            //string[] games = {"Morrowind", "BioShock", "Daxter",
            //                 "The Darkness", "Half Life", "System Shock 2"};

            //IEnumerable<string> subset =
            //    from g in games
            //    where g.Length > 6 && g.Substring(0,1)=="M"
            //    orderby g
            //    select g;

            //IEnumerable<string> subset2 = games.Where(x => x.Length > 6).OrderBy(x => x).Select(x => x);


            var productList = productService.GetAllProducts();
            return Ok(productList);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProductModel> Get(int id)
        {
            var result = productService.GetByID(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }


        // POST api/<ProductsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProductModel> Post([FromBody] ProductModel newProduct)
        {
            if (!ModelState.IsValid)  //fail fast -> return
            {
                return BadRequest();
            }

            var addedProduct=productService.AddProduct(newProduct);

            return CreatedAtAction("Get", new { id = addedProduct.Productid }, addedProduct);

        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        // [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult<ProductModel> Put(int id, [FromBody] ProductModel productToUpdate)
        {
            //exist by id or not-> validation
            if (id != productToUpdate.Productid)
            {
                return BadRequest();
            }

            // if (productService.GetByID(id) == null)
            if (!productService.Exists(id))
            {
                return NotFound();
            }

            if (!productService.CheckPrice(productToUpdate))
            {
                return Conflict("Unitprice should be greater than 50 when SupplierID = 1");
            }

            var updatedProduct = productService.UpdateProduct(productToUpdate);
            return Ok(updatedProduct);

        }

    

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]   //, Type = typeof(ProductModel) nu e cazul ca nu returnez nimic
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public IActionResult Delete(int id)
        {
            if (!productService.Exists(id))
            {
                return NotFound();
            }

            if (productService.HasOrders(id))
            {
                ModelState.AddModelError("ForeignKeyViolation", "Can't delete this, delete the orders first");

                return UnprocessableEntity(ModelState);
            }

            var IsDeleted = productService.Delete(id);
            //daca nu s-a sters return 422 status code
            if (IsDeleted == false)
                return UnprocessableEntity();
            else
             return NoContent();
        }
    }
}

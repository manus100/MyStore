using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyStore.Domain.Entities;
using MyStore.Infrastructure;
using MyStore.Models;
using MyStore.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public ActionResult<IEnumerable<OrderModel>> Get(string? city, [FromQuery] List<String>? country, Shippers shippers)
        {
            /*1. shipcity -> free value from a parameter
              2. a predefined value for: Customer
              daca parametrul este lista pot sa ii dau eu un output formatter (ca sa pot da country=France, Germany in loc de country=France&country=Germany
              daca am ca parametru o lista trebuie sa-i spun de unde sa o ia ([FromQuery])
              daca in request dau la shippers o valoare care nu apare in enum mecanismul de model binding imi va genera eroare
            */

            var allOrders = orderService.GetAll(city, country, shippers);

            var mappedOrders = mapper.Map<List<OrderModel>>(allOrders);

            return Ok(mappedOrders);
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public ActionResult<OrderModel> Get(int id)
        {
            var result = mapper.Map<OrderModel>(orderService.GetByID(id));
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public IActionResult Post([FromBody] OrderModel model)
        {
            //// orderService.AddOrder();
            //var newOrder = new Order()
            //{
            //    Orderdate=DateTime.Now,
            //    Shipaddress="random address",
            //    Shipcity="random city",
            //    Shipcountry="country",
            //    Shippostalcode="postal code",
            //    Custid=85,
            //    Empid=5,
            //    Shipperid=3,
            //    Freight=12.5M,
            //    Shipname="Name",
            //    Requireddate=DateTime.Now.AddDays(3)
            //};
            ////2 products

            //var orderDetailsList = new List<OrderDetail>();
            //var product1 = new OrderDetail
            //{
            //    Productid = 22,
            //    Discount = 0,
            //    Qty = 2,
            //    Unitprice = 12
            //};

            //var product2 = new OrderDetail
            //{
            //    Productid = 57,
            //    Discount = 0,
            //    Qty = 12,
            //    Unitprice = 12
            //};

            //orderDetailsList.Add(product1);
            //orderDetailsList.Add(product2);

            //newOrder.OrderDetails=orderDetailsList;

            //model - domain object
            var order = mapper.Map<Order>(model);

            var addedItem = orderService.Add(order);

            // do a reverse mapping Order-> OrderModel

            return CreatedAtAction("Get", new { id = addedItem.Orderid }, 
                mapper.Map<OrderModel>(addedItem));

        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public ActionResult<OrderModel> Put(int id, [FromBody] OrderModel orderModel)
        {
            if (id != orderModel.Orderid)
            {
                return BadRequest();
            };

            if (!orderService.Exists(id))
            {
                return NotFound();
            }


            var orderToUpdate = mapper.Map<Order>(orderModel);
            var result = mapper.Map<OrderModel>(orderService.UpdateOrder(orderToUpdate));
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!orderService.Exists(id))
            {
                return NotFound();
            }

            if (orderService.GetByID(id).OrderDetails.Count>0)
            {
                ModelState.AddModelError("ForeignKeyViolation", "Can't delete this, delete the order details first!");

                return UnprocessableEntity(ModelState);
            }

            var IsDeleted = orderService.Delete(id);
            //daca nu s-a sters return 422 status code
            if (IsDeleted == false)
                return UnprocessableEntity();
            else
                return NoContent();
        }

    }
}

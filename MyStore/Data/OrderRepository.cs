using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;

namespace MyStore.Data
{
    public interface IOrderRepository
    {
        void Add();

        //IEnumerable<Order> GetAll();
        IQueryable<Order> GetAll(string shipCountry, List<string> shipCities);
    }
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreContext context;

        public OrderRepository(StoreContext context)
        {
            this.context = context;
        }

        // public IEnumerable<Order> GetAll(string shipCountry)
        public IQueryable<Order> GetAll(string shipCountry, List<string> shipCities)  //de adaugat un parametru lista de shipcity
        {
            var query = this.context.Orders.Include(x => x.Cust).Select(x=>x);
            if (!string.IsNullOrEmpty(shipCountry))
            {
                query = query.Where(x => x.Shipcountry == shipCountry);
            }
            // return this.context.Orders.Include(x=>x.Cust).Select(x=>x).ToList();
            if (shipCities != null)
            {
                query = query.Where(x => shipCities.Contains(x.Shipcity));
            }

            //return context.Orders.Where(x => x.Shipcountry == shipCountry).Where(x=>shipCities.Contains(x.Shipcity)).ToList();  //merge si asa
            return query;
        }

  

        public void Add()
        {
            var newOrder = new Order
            {
                Custid = 1,
                Empid = 2,
                Orderdate = DateTime.Now,
                Shipperid=1,
                Shipname="Popescu Ion",
                Shipaddress="some address", 
                Shipcity = "Bucharest",
                Shipcountry="Romania"

            };

            var adddedOrder = context.Orders.Add(newOrder);
            context.SaveChanges();
            //return adddedOrder.Entity;

            context.OrderDetails.Add(new OrderDetail
            {
                Order = newOrder,
                Productid = 1,
                Qty = 5,
                Unitprice=10,
                Discount=0
            });

            context.SaveChanges();
        }
    }

  
}

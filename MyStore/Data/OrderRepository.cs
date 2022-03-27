using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;
using MyStore.Infrastructure;

namespace MyStore.Data
{
    public interface IOrderRepository
    {

        Order Add(Order newOrder);
        bool Delete(Order orderToDelete);
        bool Exists(int id);
        IQueryable<Order> GetAll(string? city, List<String>? country, Shippers shipper);
        Order GetByID(int id);
        Order Update(Order orderToUpdate);
    }
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreContext context;

        public OrderRepository(StoreContext context)
        {
            this.context = context;
        }


        public IQueryable<Order> GetAll(string? city, List<String>? country, Shippers shippers)  
        {
            var query = this.context.Orders
                .Include(x =>  x.OrderDetails)
                .Select(x => x);

            if (!string.IsNullOrEmpty(city))
            {
                query = query.Where(x => x.Shipcity == city);
            }

            query = query.Where(x => x.Shipperid == (int)shippers);

            if (country.Any())
            {
                query = query.Where(x => country.Contains(x.Shipcountry)) ;
            }

            //var pageNumber = 3;
            //var itemsPerPage = 20;
            //query = query.Skip(pageNumber-1*itemsPerPage).Take(itemsPerPage);
            ////query = query.Skip(10).Take(10);

            return query;
        }


        public Order GetByID(int id)
        {

          return context.Orders
                .Include("OrderDetails")
                .FirstOrDefault(x => x.Orderid == id );
        }

        public Order Add(Order newOrder)
        {
           var savedEntity= context.Orders.Add(newOrder).Entity;
            context.SaveChanges();
            return savedEntity;
        }

        public bool Exists(int id)
        {
            var exists = context.Orders.Count(x => x.Orderid == id);
            return exists == 1;
        }

        public Order Update(Order orderToUpdate)
        {
            var updatedOrder = context.Orders.Update(orderToUpdate);
            context.SaveChanges();
            return updatedOrder.Entity;
        }

        public bool Delete(Order orderToDelete)
        {
            var deletedItem = context.Orders.Remove(orderToDelete);
            context.SaveChanges();

            return deletedItem != null;
        }


        //JSON pt PUT
        //{
        // "orderid": 10906,
        //  "custid": 91,
        //  "empid": 4,
        //  "orderdate": "2016-02-25T00:00:00",
        //  "requireddate": "2016-03-11T00:00:00",
        //  "shippeddate": "2016-03-03T00:00:00",
        //  "shipperid": 3,
        //  "freight": 26.29,
        //  "shipname": "Ship to 91-B",
        //  "shipaddress": "ul. Filtrowa 6789",
        //  "shipcity": "Warszawa",
        //  "shipregion": null,
        //  "shippostalcode": "10365",
        //  "shipcountry": "Poland",
        //  "orderDetails": 
        //     [
        //      {
        //        "orderid": 10906,
        //        "productid": 61,
        //        "unitprice": 28.5,
        //        "qty": 15,
        //        "discount": 0
        //      }
        //    ]
        //}



    }

        
  
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Infrastructure;

namespace MyStore.Services
{
    public interface IOrderService
    {
        Order Add(Order newOrder);
        bool Delete(int id);
        bool Exists(int id);
        IEnumerable<Order> GetAll(string? city, List<String>? country, Shippers shipper);
        Order GetByID(int id);
        Order UpdateOrder(Order orderToUpdate);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IEnumerable<Order> GetAll(string? city,  List<String>? country, Shippers shipper)
        {
 
            var allOrders = orderRepository.GetAll(city, country, shipper).ToList();

            return allOrders;
        }

  
        public Order Add(Order newOrder)
        {
            return orderRepository.Add(newOrder);
        }

        public Order GetByID(int id)
        {
            return orderRepository.GetByID(id);
        }

        public bool Exists(int id)
        {
            return orderRepository.Exists(id);
        }

        public Order UpdateOrder(Order orderToUpdate)
        {
            return orderRepository.Update(orderToUpdate);
        }

        public bool Delete(int id)
        {
            var itemToDelete = orderRepository.GetByID(id);

            if (itemToDelete == null)
            {
                //eroare
                return false;
            }
            return orderRepository.Delete(itemToDelete);
        }
    }
}

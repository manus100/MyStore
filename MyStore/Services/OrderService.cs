using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Data;
using MyStore.Domain.Entities;

namespace MyStore.Services
{
    public interface IOrderService
    {
        void AddOrder();
        IEnumerable<Order> GetAll();
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository repository;

        public OrderService(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Order> GetAll()
        {
            List<string> shipCities = new() { "Seattle", "Portland" };

            var allOrders = repository.GetAll("USA", shipCities).ToList();

            return allOrders;
        }

        public void AddOrder()
        {
            repository.Add();
        }
    }
}

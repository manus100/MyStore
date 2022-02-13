using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Domain.Entities;

namespace MyStore.Data
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer GetByID(int id);
    }
    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreContext context;

        public CustomerRepository(StoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return context.Customers.ToList();
        }

        public IEnumerable<Customer> FindByCity(string city)
        {
            return context.Customers.Where(x => x.City == city).Select(x => x);
        }

        public Customer GetByID(int id)
        {
            return context.Customers.Find(id);
        }
    }
}

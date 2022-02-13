using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Data;
using MyStore.Domain.Entities;

namespace MyStore.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer GetByID(int id);
    }

    public class CustomerService :ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetAll()
        {
            return customerRepository.GetAll();
        }

        public Customer GetByID (int id)
        {
            return customerRepository.GetByID(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Models;

namespace MyStore.Services
{
    public interface ICustomerService
    {
        CustomerModel AddCustomer(CustomerModel newCustomer);
        bool Delete(int id);
        bool Exists(int id);
        IEnumerable<CustomerModel> GetAll();
        CustomerModel GetByID(int id);
        void UpdateCustomer(CustomerModel model);
    }

    public class CustomerService :ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        public IEnumerable<CustomerModel> GetAll()
        {
           var allCustomers = customerRepository.GetAll();

            return mapper.Map<IEnumerable<CustomerModel>>(allCustomers);
        }

        public CustomerModel GetByID (int id)
        {
            Customer customer = customerRepository.GetByID(id);
            return mapper.Map<CustomerModel>(customer);
        }

        public CustomerModel AddCustomer(CustomerModel newCustomer)
        {
            Customer customerToAdd = mapper.Map<Customer>(newCustomer);
            var addedCustomer = customerRepository.Add(customerToAdd);

            return mapper.Map<CustomerModel>(addedCustomer);
        }

        public void UpdateCustomer(CustomerModel model)
        {
            Customer customerToUpdate = mapper.Map<Customer>(model);
            customerRepository.Update(customerToUpdate);
        }

        public bool Exists(int id)
        {
            return customerRepository.Exists(id);
        }

        public bool Delete(int id)
        {
            var itemToDelete = customerRepository.GetByID(id);
            if (itemToDelete != null) //poate s-a intamplat ceva intre timp si l-a sters altcineva inaintea mea
                return customerRepository.Delete(itemToDelete);
            else
                return false;
        }
    }
}

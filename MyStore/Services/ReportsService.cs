using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Domain.Extensions;

namespace MyStore.Services
{
    public class ReportsService : IReportsService
    {
        private readonly IReportsRepository reportsRepository;

        public ReportsService(IReportsRepository reportsRepository)
        {
            this.reportsRepository = reportsRepository;
        }

        public List<Customer> GetCustomersWithNoOrders()
        {
            return reportsRepository.GetCustomersWithNoOrders();
        }

        public List<CustomerContact> GetContacts()
        {
            var result = reportsRepository.GetContacts();

            return result;
        }

        public CustomersOfAProduct GetNbOfCustomers(int id)
        {
            var result = reportsRepository.GetNbOfCustomers(id);

            return result;
        }
    }

    public interface IReportsService
    {
        List<CustomerContact> GetContacts();
        List<Customer> GetCustomersWithNoOrders();
        CustomersOfAProduct GetNbOfCustomers(int id);
    }
}

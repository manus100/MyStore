using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MyStore.Models;
using MyStore.Services;

namespace MyStore.Tests.Mocks.Services
{
   public class MockCustomerService : Mock<ICustomerService>
    {
        public MockCustomerService MockGetAllCustomers(List<CustomerModel> results)
        {
            Setup(x => x.GetAll()).Returns(results);

            return this;
        }

        public MockCustomerService MockGetByID(CustomerModel customer)
        {
            Setup(x => x.GetByID(It.IsAny<int>()))
                .Returns(customer);

            return this;
        }
    }
}

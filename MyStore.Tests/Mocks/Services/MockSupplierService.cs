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
    public class MockSupplierService : Mock<ISupplierService>
    {
        public MockSupplierService MockGetAllSupplier(List<SupplierModel> results)
        {
            Setup(x => x.GetAll()).Returns(results);

            return this;
        }

        public MockSupplierService MockGetByID(SupplierModel supplier)
        {
            Setup(x => x.GetByID(It.IsAny<int>()))
                .Returns(supplier);

            return this;
        }
    }
}
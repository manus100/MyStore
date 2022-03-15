using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MyStore.Models;
using MyStore.Service;

namespace MyStore.Tests.Mocks.Services
{
   public class MockShipperService : Mock<IShipperService>
    {
        public MockShipperService MockGetAllShippers(List<ShipperModel> results)
        {
            Setup(x => x.GetAll()).Returns(results);

            return this;
        }

        public MockShipperService MockGetByID(ShipperModel shipper)
        {
            Setup(x => x.GetByID(It.IsAny<int>()))
                .Returns(shipper);

            return this;
        }
    }
}


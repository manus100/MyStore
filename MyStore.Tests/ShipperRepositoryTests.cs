using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MyStore.Data;
using MyStore.Domain.Entities;
using Xunit;

namespace MyStore.Tests
{
    public class ShipperRepositoryTests
    {
        [Fact]
        public void Should_GetAllCustomers()
        {
            //arrange
            var mocRepo = new Mock<IShipperRepository>();
            mocRepo.Setup(repo => repo.GetAll())
                .Returns(ReturnMultiple());

            //act
            var result = mocRepo.Object.GetAll();

            //asert
            Assert.Equal(2, result.Count());
            Assert.IsType<List<Shipper>>(result);

        }

        private List<Shipper> ReturnMultiple()
        {
            return new List<Shipper>()
                 {
                    new Shipper
                    {
                        Shipperid = Consts.ShipperIDTest1,
                        Companyname = Consts.ShipperCompanyName,
                        Phone = Consts.Phone
                    },
                    new Shipper
                    {
                        Shipperid = Consts.ShipperIDTest2,
                        Companyname = Consts.ShipperCompanyName,
                        Phone = Consts.Phone
                    } };
        }
    }

}

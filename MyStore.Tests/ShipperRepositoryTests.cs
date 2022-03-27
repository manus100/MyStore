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
        public void Should_GetAllShippers()
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

        [Fact]
        public void Should_GetOneShipper()
        {
            //arrange
            var mocRepo = new Mock<IShipperRepository>();
            mocRepo.Setup(repo => repo.GetByID(ShipperConsts.ShipperId))
                .Returns(ReturnOneShipper(ShipperConsts.ShipperId));

            //act
            var result = mocRepo.Object.GetByID(ShipperConsts.ShipperId);

            //asert
            Assert.Equal(ShipperConsts.ShipperId, result.Shipperid);
            Assert.IsType<Shipper>(result);

        }

        [Fact]
        public void Shoul_Return_Shipper_On_Post()
        {
            //arrange
            var mocRepo = new Mock<IShipperRepository>();
            mocRepo.Setup(repo => repo.Add(It.IsAny<Shipper>()))
                .Returns(ReturnOneShipper(ShipperConsts.ShipperId));

            //act
            var result = mocRepo.Object.Add(ReturnOneShipper(ShipperConsts.ShipperId));

            //asert
            Assert.Equal(ShipperConsts.ShipperCompanyName, result.Companyname);
            Assert.IsType<Shipper>(result);

        }

        [Fact]
        public void ShouldReturn_Shipper_On_Put()
        {
            //arrange
            var mocRepo = new Mock<IShipperRepository>();
            mocRepo.Setup(repo => repo.Update(It.IsAny<Shipper>()))
                .Returns(ReturnOneShipper(ShipperConsts.ShipperId));

            //act
            var result = mocRepo.Object.Update(ReturnOneShipper(ShipperConsts.ShipperId));

            //asert
            Assert.Equal(ShipperConsts.ShipperCompanyName, result.Companyname);
            Assert.IsType<Shipper>(result);

        }

        [Fact]
        public void Shoul_Return_True_On_Delete()
        {
            //arrange
            var mocRepo = new Mock<IShipperRepository>();
            mocRepo.Setup(repo => repo.Delete(It.IsAny<Shipper>()))
                .Returns(true);

            //act
            var result = mocRepo.Object.Delete(ReturnOneShipper(CategoryConsts.Categoryid));

            //asert
            Assert.True(result);

        }


        private Shipper ReturnOneShipper(int i)
        {
            IEnumerable<Shipper> shippers = ReturnMultiple();
            return shippers.Where(x => x.Shipperid == i).FirstOrDefault();
        }
        private List<Shipper> ReturnMultiple()
        {
            return new List<Shipper>()
                 {
                    new Shipper
                    {
                        Shipperid = ShipperConsts.ShipperId,
                        Companyname = ShipperConsts.ShipperCompanyName,
                        Phone = ShipperConsts.Phone
                    },
                    new Shipper
                    {
                        Shipperid = ShipperConsts.ShipperId2,
                        Companyname = ShipperConsts.ShipperCompanyName,
                        Phone = ShipperConsts.Phone
                    } };
        }
    }

}

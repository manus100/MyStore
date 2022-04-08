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
   public class SupplierRepositoryTests
    {
        private Mock<ISupplierRepository> mockRepo;
        public SupplierRepositoryTests()
        {
            mockRepo = new Mock<ISupplierRepository>();
        }

        [Fact]
        public void Should_GetAllCustomers()
        {
            //arrange
            mockRepo.Setup(repo => repo.GetAll())
                .Returns(ReturnMultiple());

            //act
            var result = mockRepo.Object.GetAll();

            //asert
            Assert.Equal(2, result.Count());
            Assert.IsType<List<Supplier>>(result);

        }

        [Fact]
        public void Should_GetOneCategory()
        {
            //arrange
            mockRepo.Setup(repo => repo.GetByID(CustomerSupplierConsts.SupplierId))
                .Returns(ReturnOneSupplier(CustomerSupplierConsts.SupplierId));

            //act
            var result = mockRepo.Object.GetByID(CustomerSupplierConsts.SupplierId);

            //asert
            Assert.Equal(CustomerSupplierConsts.SupplierCompanyName, result.Companyname);
            Assert.IsType<Supplier>(result);

        }

        [Fact]
        public void Shoul_Return_Supplier_On_Post()
        {
            //arrange
            mockRepo.Setup(repo => repo.AddSupplier(It.IsAny<Supplier>()))
                .Returns(ReturnOneSupplier(CustomerSupplierConsts.SupplierId));

            //act
            var result = mockRepo.Object.AddSupplier(ReturnOneSupplier(CustomerSupplierConsts.SupplierId));

            //asert
            Assert.Equal(CustomerSupplierConsts.SupplierCompanyName, result.Companyname);
            Assert.IsType<Supplier>(result);

        }

        [Fact]
        public void ShouldReturn_Supplier_On_Put()
        {
            //arrange
            mockRepo.Setup(repo => repo.Update(It.IsAny<Supplier>()))
                .Returns(ReturnOneSupplier(CustomerSupplierConsts.SupplierId));

            //act
            var result = mockRepo.Object.Update(ReturnOneSupplier(CustomerSupplierConsts.SupplierId));

            //asert
            Assert.Equal(CustomerSupplierConsts.SupplierCompanyName, result.Companyname);
            Assert.IsType<Supplier>(result);

        }

        [Fact]
        public void Shoul_Return_True_On_Delete()
        {
            //arrange
            mockRepo.Setup(repo => repo.Delete(It.IsAny<Supplier>()))
                .Returns(true);

            //act
            var result = mockRepo.Object.Delete(ReturnOneSupplier(CustomerSupplierConsts.SupplierId));

            //asert
            Assert.True(result);

        }


        private Supplier ReturnOneSupplier(int i)
        {
            IEnumerable<Supplier> suppliers = ReturnMultiple();
            return suppliers.Where(x => x.Supplierid == i).FirstOrDefault();
        }
        private List<Supplier> ReturnMultiple()
        {
            return new List<Supplier>()
                 {
                    new Supplier
                    {
                        Supplierid = CustomerSupplierConsts.SupplierId,
                        Companyname = CustomerSupplierConsts.SupplierCompanyName,
                        Contactname = CustomerSupplierConsts.ContactName,
                        Contacttitle = CustomerSupplierConsts.ContactTitle,
                        Address = CustomerSupplierConsts.Address,
                        City = CustomerSupplierConsts.City,
                        Region = CustomerSupplierConsts.Region,
                        Postalcode = CustomerSupplierConsts.PostalCode,
                        Country = CustomerSupplierConsts.Country,
                        Phone = CustomerSupplierConsts.Phone,
                        Fax = CustomerSupplierConsts.Fax
                    },
                    new Supplier
                    {
                        Supplierid = CustomerSupplierConsts.SupplierId2,
                        Companyname = CustomerSupplierConsts.SupplierCompanyName,
                        Contactname = CustomerSupplierConsts.ContactName,
                        Contacttitle = CustomerSupplierConsts.ContactTitle,
                        Address = CustomerSupplierConsts.Address,
                        City = CustomerSupplierConsts.City,
                        Region = CustomerSupplierConsts.Region,
                        Postalcode = CustomerSupplierConsts.PostalCode,
                        Country = CustomerSupplierConsts.Country,
                        Phone = CustomerSupplierConsts.Phone,
                        Fax = CustomerSupplierConsts.Fax
                    } };
        }
    }

}

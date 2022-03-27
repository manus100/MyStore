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
        [Fact]
        public void Should_GetAllCustomers()
        {
            //arrange
            var mocRepo = new Mock<ISupplierRepository>();
            mocRepo.Setup(repo => repo.GetAll())
                .Returns(ReturnMultiple());

            //act
            var result = mocRepo.Object.GetAll();

            //asert
            Assert.Equal(2, result.Count());
            Assert.IsType<List<Supplier>>(result);

        }

        [Fact]
        public void Should_GetOneCategory()
        {
            //arrange
            var mocRepo = new Mock<ISupplierRepository>();
            mocRepo.Setup(repo => repo.GetByID(CustomerSupplierConsts.SupplierId))
                .Returns(ReturnOneSupplier(CustomerSupplierConsts.SupplierId));

            //act
            var result = mocRepo.Object.GetByID(CustomerSupplierConsts.SupplierId);

            //asert
            Assert.Equal(CustomerSupplierConsts.SupplierCompanyName, result.Companyname);
            Assert.IsType<Supplier>(result);

        }

        [Fact]
        public void Shoul_Return_Supplier_On_Post()
        {
            //arrange
            var mocRepo = new Mock<ISupplierRepository>();
            mocRepo.Setup(repo => repo.AddSupplier(It.IsAny<Supplier>()))
                .Returns(ReturnOneSupplier(CustomerSupplierConsts.SupplierId));

            //act
            var result = mocRepo.Object.AddSupplier(ReturnOneSupplier(CustomerSupplierConsts.SupplierId));

            //asert
            Assert.Equal(CustomerSupplierConsts.SupplierCompanyName, result.Companyname);
            Assert.IsType<Supplier>(result);

        }

        [Fact]
        public void ShouldReturn_Supplier_On_Put()
        {
            //arrange
            var mocRepo = new Mock<ISupplierRepository>();
            mocRepo.Setup(repo => repo.Update(It.IsAny<Supplier>()))
                .Returns(ReturnOneSupplier(CustomerSupplierConsts.SupplierId));

            //act
            var result = mocRepo.Object.Update(ReturnOneSupplier(CustomerSupplierConsts.SupplierId));

            //asert
            Assert.Equal(CustomerSupplierConsts.SupplierCompanyName, result.Companyname);
            Assert.IsType<Supplier>(result);

        }

        [Fact]
        public void Shoul_Return_True_On_Delete()
        {
            //arrange
            var mocRepo = new Mock<ISupplierRepository>();
            mocRepo.Setup(repo => repo.Delete(It.IsAny<Supplier>()))
                .Returns(true);

            //act
            var result = mocRepo.Object.Delete(ReturnOneSupplier(CustomerSupplierConsts.SupplierId));

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

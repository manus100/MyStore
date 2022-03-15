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

        private List<Supplier> ReturnMultiple()
        {
            return new List<Supplier>()
                 {
                    new Supplier
                    {
                        Supplierid = Consts.SupplierIDTest1,
                        Companyname = Consts.SupplierCompanyName,
                        Contactname = Consts.ContactName,
                        Contacttitle = Consts.ContactTitle,
                        Address = Consts.Address,
                        City = Consts.City,
                        Region = Consts.Region,
                        Postalcode = Consts.PostalCode,
                        Country = Consts.Country,
                        Phone = Consts.Phone,
                        Fax = Consts.Fax
                    },
                    new Supplier
                    {
                        Supplierid = Consts.SupplierIDTest2,
                        Companyname = Consts.SupplierCompanyName,
                        Contactname = Consts.ContactName,
                        Contacttitle = Consts.ContactTitle,
                        Address = Consts.Address,
                        City = Consts.City,
                        Region = Consts.Region,
                        Postalcode = Consts.PostalCode,
                        Country = Consts.Country,
                        Phone = Consts.Phone,
                        Fax = Consts.Fax
                    } };
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Models;
using Xunit;

namespace MyStore.Tests
{
    public class CustomerRepositoryTests
    {
        [Fact]
        public void Should_GetAllCustomers()
        {
            //arrange
            var mocRepo = new Mock<ICustomerRepository>();
            mocRepo.Setup(repo => repo.GetAll())
                .Returns(ReturnMultiple());

            //act
            var result = mocRepo.Object.GetAll();

            //asert
            Assert.Equal(2, result.Count());
            Assert.IsType<List<Customer>>(result);

        }

        private List<Customer> ReturnMultiple()
        {
            return new List<Customer>()
                 {
                    new Customer
                    {
                        Custid = Consts.CustIDTest1,
                        Companyname = Consts.CompanyName,
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
                    new Customer
                    {
                        Custid = Consts.CustIDTest2,
                        Companyname = Consts.CompanyName,
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



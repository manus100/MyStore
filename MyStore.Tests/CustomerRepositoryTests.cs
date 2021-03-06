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
        private Mock<ICustomerRepository> mockRepo;
        public CustomerRepositoryTests()
        {
            mockRepo = new Mock<ICustomerRepository>();
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
            Assert.IsType<List<Customer>>(result);

        }

        [Fact]
        public void Should_GetOneCustomer()
        {
            //arrange
            mockRepo.Setup(repo => repo.GetByID(CustomerSupplierConsts.CustId))
                .Returns(ReturnOneCustomer(CustomerSupplierConsts.CustId));

            //act
            var result = mockRepo.Object.GetByID(CustomerSupplierConsts.CustId);

            //asert
            Assert.Equal(CustomerSupplierConsts.CustId, result.Custid);
            Assert.IsType<Customer>(result);

        }

        [Fact]
        public void Shoul_Return_Customer_On_Post()
        {
            //arrange
            mockRepo.Setup(repo => repo.Add(It.IsAny<Customer>()))
                .Returns(ReturnOneCustomer(CustomerSupplierConsts.CustId));

            //act
            var result = mockRepo.Object.Add(ReturnOneCustomer(CustomerSupplierConsts.CustId));

            //asert
            Assert.Equal(CustomerSupplierConsts.ContactName, result.Contactname);
            Assert.IsType<Customer>(result);

        }

        [Fact]
        public void ShouldReturn_Customer_On_Put()
        {
            //arrange
            mockRepo.Setup(repo => repo.Update(It.IsAny<Customer>()))
                 .Returns(ReturnOneCustomer(CustomerSupplierConsts.CustId));

            //act
            var result = mockRepo.Object.Update(ReturnOneCustomer(CustomerSupplierConsts.CustId));

            //asert
            Assert.Equal(CustomerSupplierConsts.ContactName, result.Contactname);
            Assert.IsType<Customer>(result);

        }

        [Fact]
        public void Shoul_Return_True_On_Delete()
        {
            //arrange
            mockRepo.Setup(repo => repo.Delete(It.IsAny<Customer>()))
                .Returns(true);

            //act
            var result = mockRepo.Object.Delete(ReturnOneCustomer(CustomerSupplierConsts.CustId));

            //asert
            Assert.True(result);

        }


        private Customer ReturnOneCustomer(int i)
        {
            IEnumerable<Customer> customers = ReturnMultiple();
            return customers.Where(x => x.Custid == i).FirstOrDefault();
        }

        private List<Customer> ReturnMultiple()
        {
            return new List<Customer>()
                 {
                    new Customer
                    {
                        Custid = CustomerSupplierConsts.CustId,
                        Companyname = CustomerSupplierConsts.CompanyName,
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
                    new Customer
                    {
                        Custid = CustomerSupplierConsts.CustId2,
                        Companyname = CustomerSupplierConsts.CompanyName,
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



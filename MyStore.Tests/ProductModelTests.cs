using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStore.Domain.Entities;
using MyStore.Models;
using Xunit;


namespace MyStore.Tests 
{
    public class ProductModelTests
    {
        public const string ProductNameRequiredMessage = "Product name is required!";
        public const int ValidCategoryId = 2;

        //[Fact]
        //public void FailingTest()
        //{
        //    Assert.Equal(2,3);
        //}

        [Fact]
        public void Should_Pass()  //validez ca ProductModel e corect
        {
            //arrange
            var sut = new ProductModel()   //subject under test
            {
                Categoryid = CategoryConsts.Categoryid,
                Productid = ProductConsts.Product2Id,
                Supplierid = CustomerSupplierConsts.SupplierId,
                Unitprice = ProductConsts.UnitPriceTest,
                Discontinued = ProductConsts.DiscontinuedTest,
                Productname = ProductConsts.ProductName2
            };

            //act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResults, true);

            //assert
            Assert.True(actual, "Expected to succeed");

        }
        [Fact]
        public void ShouldFailWhenProductNameIsEmpty()
        {
            //arrange
            var sut = new ProductModel()
            {
                Categoryid = CategoryConsts.Categoryid,
                Productid = ProductConsts.Product2Id,
                Supplierid = CustomerSupplierConsts.SupplierId,
                Unitprice = ProductConsts.UnitPriceTest,
                Discontinued = ProductConsts.DiscontinuedTest,
                Productname = ""
            };

            //act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResults, true);

            //assert
            var message = validationResults[0];
            Assert.Equal(ProductNameRequiredMessage, message.ErrorMessage);

        }
    }
}

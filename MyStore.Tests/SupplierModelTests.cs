using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStore.Models;
using Xunit;

namespace MyStore.Tests
{
    public class SupplierModelTests
    {
   
            [Fact]
            public void Should_Pass()
            {
                //arrange
                var sut = new SupplierModel()
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
                };

                //act
                var validationResults = new List<ValidationResult>();
                var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResults, true);

                //assert
                Assert.True(actual, "Expected to succeed");
            }

            [Fact]
            public void ShouldFailWhenCompanyNameIsEmpty()
            {
                //arrange
                var sut = new SupplierModel()
                {
                    Supplierid = CustomerSupplierConsts.SupplierId,
                    Companyname = "",
                    Contactname = CustomerSupplierConsts.ContactName,
                    Contacttitle = CustomerSupplierConsts.ContactTitle,
                    Address = CustomerSupplierConsts.Address,
                    City = CustomerSupplierConsts.City,
                    Region = CustomerSupplierConsts.Region,
                    Postalcode = CustomerSupplierConsts.PostalCode,
                    Country = CustomerSupplierConsts.Country,
                    Phone = CustomerSupplierConsts.Phone,
                    Fax = CustomerSupplierConsts.Fax
                };

                //act
                var validationResults = new List<ValidationResult>();
                var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResults, true);

                //assert

                var message = validationResults[0];
                Assert.Equal(ProductConsts.CompanyNameRequiredMessage, message.ErrorMessage);
            }

        }
    }


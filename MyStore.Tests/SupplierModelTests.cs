﻿using System;
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
        public class CustomerModelTests
        {
            [Fact]
            public void Should_Pass()
            {
                //arrange
                var sut = new SupplierModel()
                {
                    Supplierid = Consts.SupplierIDTest,
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
                    Supplierid = Consts.SupplierIDTest,
                    Companyname = "",
                    Contactname = Consts.ContactName,
                    Contacttitle = Consts.ContactTitle,
                    Address = Consts.Address,
                    City = Consts.City,
                    Region = Consts.Region,
                    Postalcode = Consts.PostalCode,
                    Country = Consts.Country,
                    Phone = Consts.Phone,
                    Fax = Consts.Fax
                };

                //act
                var validationResults = new List<ValidationResult>();
                var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResults, true);

                //assert

                var message = validationResults[0];
                Assert.Equal(Consts.CompanyNameRequiredMessage, message.ErrorMessage);
            }

        }
    }
}
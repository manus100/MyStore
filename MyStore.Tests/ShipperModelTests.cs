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
  public  class ShipperModelTests
    {
        [Fact]
        public void Should_Pass()
        {
            //arrange
            var sut = new ShipperModel()
            {
                Shipperid = Consts.ShipperIDTest,
                Companyname = Consts.ShipperCompanyName,
                Phone = Consts.Phone
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
            var sut = new ShipperModel()
            {
                Companyname = "",
                Phone = Consts.Phone
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


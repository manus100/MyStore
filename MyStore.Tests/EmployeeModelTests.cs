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
  public  class EmployeeModelTests
    {
        [Fact]
        public void Should_Pass()
        {
            //arrange
            var sut = new EmployeeModel()
            {
                Empid = Consts.EmpIDTest1,
                Lastname = Consts.LastNameTest1,
                Firstname = Consts.FirstNameTest1,
                Title = Consts.Title,
                Titleofcourtesy = Consts.Titleofcourtesy,
                Birthdate = Consts.BirthDate,
                Hiredate = Consts.HireDate,
                Address = Consts.Address,
                City = Consts.City,
                Region = Consts.Region,
                Country = Consts.Country,
                Phone = Consts.Phone,
                Mgrid = Consts.MgrID
            };

            //act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResults, true);

            //assert
            Assert.True(actual, "Expected to succeed");
        }

        [Fact]
        public void ShouldFailWhenLastNameIsEmpty()
        {
            //arrange
            var sut = new EmployeeModel()
            {
                Empid = Consts.EmpIDTest1,
                Lastname = "",
                Firstname = Consts.FirstNameTest1,
                Title = Consts.Title,
                Titleofcourtesy = Consts.Titleofcourtesy,
                Birthdate = Consts.BirthDate,
                Hiredate = Consts.HireDate,
                Address = Consts.Address,
                City = Consts.City,
                Region = Consts.Region,
                Country = Consts.Country,
                Phone = Consts.Phone,
                Mgrid = Consts.MgrID
            };

            //act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResults, true);

            //assert

            var message = validationResults[0];
            Assert.Equal(Consts.LastNameRequiredMessage, message.ErrorMessage);
        }

    }
}

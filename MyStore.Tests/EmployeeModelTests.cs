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
                Empid = EmployeeConsts.EmpId,
                Lastname = EmployeeConsts.LastName1,
                Firstname = EmployeeConsts.FirstName1,
                Title = EmployeeConsts.Title,
                Titleofcourtesy = EmployeeConsts.Titleofcourtesy,
                Birthdate = EmployeeConsts.BirthDate,
                Hiredate = EmployeeConsts.HireDate,
                Address = EmployeeConsts.Address,
                City = EmployeeConsts.City,
                Region = EmployeeConsts.Region,
                Country = EmployeeConsts.Country,
                Phone = EmployeeConsts.Phone,
                Mgrid = EmployeeConsts.MgrID
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
                Empid = EmployeeConsts.EmpId,
                Lastname = "",
                Firstname = EmployeeConsts.FirstName1,
                Title = EmployeeConsts.Title,
                Titleofcourtesy = EmployeeConsts.Titleofcourtesy,
                Birthdate = EmployeeConsts.BirthDate,
                Hiredate = EmployeeConsts.HireDate,
                Address = EmployeeConsts.Address,
                City = EmployeeConsts.City,
                Region = EmployeeConsts.Region,
                Country = EmployeeConsts.Country,
                Phone = EmployeeConsts.Phone,
                Mgrid = EmployeeConsts.MgrID
            };

            //act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResults, true);

            //assert

            var message = validationResults[0];
            Assert.Equal(EmployeeConsts.LastNameRequiredMessage, message.ErrorMessage);
        }

    }
}

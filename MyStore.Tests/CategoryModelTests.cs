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
    public class CategoryModelTests
    {
 
        [Fact]
        public void Should_Pass()
        {
            //arrange
            var sut = new CategoryModel()   
            {
                Categoryname = Consts.ValidCategoryName,
                Description = Consts.ValidCategoryDescription
            };

            //act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResults, true);

            //assert
            Assert.True(actual, "Expected to succeed");
        }

        [Fact]
        public void ShouldFailWhenCategoryNameIsEmpty()
        {
            //arrange
            var sut = new CategoryModel()
            {
                Categoryname = "",
                Description = Consts.ValidCategoryDescription
            };

            //act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResults, true);

            //assert
            //var message = validationResults;

            //for (int i = 0; i < validationResults.Count; i++)
            //{
            //    Assert.Equal(validationResults[i].ErrorMessage, message[i].ErrorMessage);
            //}
            var message = validationResults[0];
            Assert.Equal(Consts.CategoryNameRequiredMessage, message.ErrorMessage);
        }

    }
}

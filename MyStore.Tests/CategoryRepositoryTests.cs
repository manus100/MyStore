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
    public class CategoryRepositoryTests
    {

        public CategoryRepositoryTests()
        {

        }
        [Fact]
        public void Should_GetAllCategories()
        {
            //arrange
            var mocRepo = new Mock<ICategoryRepository>();
            mocRepo.Setup(repo => repo.GetAll())
                .Returns(ReturnMultiple());

            //act
            var result = mocRepo.Object.GetAll();

            //asert
            Assert.Equal(2, result.Count());
            Assert.IsType<List<Category>>(result);

        }

        private List<Category> ReturnMultiple()
        {
            return new List<Category>()
                    {
                        new Category{
                            Categoryname="test 1",
                            Description = "Description 1"
                        },
                       new Category{
                            Categoryname="test 2",
                            Description = "Description 2"
                        }
                    };
        }


    }
}


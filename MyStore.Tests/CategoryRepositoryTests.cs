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
    public class CategoryRepositoryTests
    {
        private Mock<ICategoryRepository> mockRepo;
        public CategoryRepositoryTests()
        {
            mockRepo = new Mock<ICategoryRepository>();
        }

        [Fact]
        public void Should_GetAllCategories()
        {
            //arrange
            mockRepo.Setup(repo => repo.GetAll())
                .Returns(ReturnMultiple());

            //act
            var result = mockRepo.Object.GetAll();

            //asert
            Assert.Equal(2, result.Count());
            Assert.IsType<List<Category>>(result);

        }

        [Fact]
        public void Should_GetOneCategory()
        {
            //arrange
            mockRepo.Setup(repo => repo.GetByID(CategoryConsts.Categoryid))
                .Returns(ReturnOneCategory(CategoryConsts.Categoryid));

            //act
            var result = mockRepo.Object.GetByID(CategoryConsts.Categoryid);

            //asert
            Assert.Equal(CategoryConsts.Categoryid, result.Categoryid);
            Assert.IsType<Category>(result);

        }

        [Fact]
        public void Shoul_Return_Category_On_Post()
        {
            //arrange
            mockRepo.Setup(repo => repo.Add(It.IsAny<Category>()))
                .Returns(ReturnOneCategory(CategoryConsts.Categoryid));

            //act
            var result = mockRepo.Object.Add(ReturnOneCategory(CategoryConsts.Categoryid));

            //asert
            Assert.Equal(CategoryConsts.Categoryname, result.Categoryname);
            Assert.IsType<Category>(result);

        }

        [Fact]
        public void ShouldReturn_Category_On_Put()
        {
            //arrange
            mockRepo.Setup(repo => repo.Update(It.IsAny<Category>()))
                .Returns(ReturnOneCategory(CategoryConsts.Categoryid));

            //act
            var result = mockRepo.Object.Update(ReturnOneCategory(CategoryConsts.Categoryid));

            //asert
            Assert.Equal(CategoryConsts.Categoryname, result.Categoryname);
            Assert.IsType<Category>(result);

        }

        [Fact]
        public void Shoul_Return_True_On_Delete()
        {
            //arrange
            mockRepo.Setup(repo => repo.Delete(It.IsAny<Category>()))
                .Returns(true);

            //act
            var result = mockRepo.Object.Delete(ReturnOneCategory(CategoryConsts.Categoryid));

            //asert
           Assert.True(result);
         
        }


        private Category ReturnOneCategory(int i)
        {
            IEnumerable<Category> categories = ReturnMultiple();
            return categories.Where(x => x.Categoryid == i).FirstOrDefault();
        }

        private List<Category> ReturnMultiple()
        {
            return new List<Category>()
                   {
                       new Category
                       {
                            Categoryid = CategoryConsts.Categoryid,
                            Categoryname = CategoryConsts.Categoryname,
                            Description = CategoryConsts.Description
                        },
                       new Category
                       {
                            Categoryid = CategoryConsts.Categoryid2,
                            Categoryname = CategoryConsts.Categoryname2,
                            Description = CategoryConsts.Description2
                        }
                   };
        }


    }
}


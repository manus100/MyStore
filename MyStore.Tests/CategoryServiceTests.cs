using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Infrastructure;
using MyStore.Models;
using MyStore.Services;
using Xunit;

namespace MyStore.Tests
{
    public class CategoryServiceTests
    {
        private readonly Mock<ICategoryRepository> mockCategoryRepository;
        private readonly IMapper mapper;

        public CategoryServiceTests()
        {
            mockCategoryRepository = new Mock<ICategoryRepository>();
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CategoryProfile());
            }).CreateMapper();
        }

        [Fact]
        public void Should_Return_ListOfCategoryModel_On_GetALL()
        {
            //arrange
            mockCategoryRepository.Setup(x => x.GetAll())
                .Returns(new List<Category> { new Category() { } });

            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile(new ProductProfile());
            //});
            //var mapper = config.CreateMapper();


            var service = new CategoryService(mockCategoryRepository.Object, mapper);

            //act
            var response = service.GetAll();

            //assert
            Assert.IsType<List<CategoryModel>>(response.ToList());

        }

        [Fact]
        public void Should_Return_AllCategories()
        {
            //arrange
            mockCategoryRepository.Setup(x => x.GetAll())
                .Returns(ReturnMultiple());

            var service = new CategoryService(mockCategoryRepository.Object, mapper);

            //act
            var response = service.GetAll();

            //assert
            Assert.Equal(ReturnMultiple().Count(), response.Count());
            Assert.IsType<List<CategoryModel>>(response as IEnumerable<CategoryModel>);
        }

        [Fact]
        public void Shoul_Return_OneCategory_On_GetById()
        {
            //arrange
            mockCategoryRepository.Setup(x => x.GetByID(CategoryConsts.Categoryid))
             .Returns(ReturnOneCategory(CategoryConsts.Categoryid));

            var service = new CategoryService(mockCategoryRepository.Object, mapper);

            //act
            var response = service.GetByID(CategoryConsts.Categoryid);


            //assert

            Assert.IsType<CategoryModel>(response);
            Assert.Equal(CategoryConsts.Categoryid, response.Categoryid);

        }

        [Fact]
        public void Shoul_Return_CategoryModel_On_Post()
        {
            //arrange
            mockCategoryRepository.Setup(x => x.Add(It.IsAny<Category>()))
            .Returns(ReturnOneCategory(CategoryConsts.Categoryid));

            var service = new CategoryService(mockCategoryRepository.Object, mapper);

            //act
            var response = service.Add(ReturnOneCategoryModel());

            //assert
            Assert.IsType<CategoryModel>(response);
            Assert.Equal(CategoryConsts.Categoryname, response.Categoryname);
        }

        [Fact]
        public void ShouldReturn_Model_On_Put()
        {
            //arrange
            mockCategoryRepository.Setup(x => x.Update(ReturnOneCategory(CategoryConsts.Categoryid)))
            .Returns(ReturnOneCategory(CategoryConsts.Categoryid));

            var service = new CategoryService(mockCategoryRepository.Object, mapper);
            mockCategoryRepository.Setup(x => x.Update(It.IsAny<Category>())).Returns(ReturnOneCategory(CategoryConsts.Categoryid));

            //act
            var response = service.Update(ReturnOneCategoryModel());

            //asert
            Assert.Equal(CategoryConsts.Categoryname, response.Categoryname);
            Assert.IsType<CategoryModel>(response);

        }

        [Fact]
        public void ShouldReturn_True_On_Delete()
        {
            //arrange
            mockCategoryRepository.Setup(x => x.Delete(ReturnOneCategory(CategoryConsts.Categoryid)))
            .Returns(true);

            var service = new CategoryService(mockCategoryRepository.Object, mapper);
            mockCategoryRepository.Setup(x => x.Delete(It.IsAny<Category>())).Returns(true);
            mockCategoryRepository.Setup(x => x.GetByID(It.IsAny<int>())).Returns(ReturnOneCategory(1));

            //act
            var response = service.Delete(CategoryConsts.Categoryid);

            // Assert
            Assert.True(response);

        }

        private Category ReturnOneCategory(int i)
        {
            IEnumerable<Category> categories = ReturnMultiple();
            return categories.Where(x => x.Categoryid == i).FirstOrDefault();
        }

        private CategoryModel ReturnOneCategoryModel()
        {
            CategoryModel model = new CategoryModel
            {
                Categoryid = CategoryConsts.Categoryid,
                Categoryname = CategoryConsts.Categoryname,
                Description = CategoryConsts.Description
            };

            return model;
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

    

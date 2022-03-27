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
using MyStore.Tests.Mocks.Services;
using Xunit;

namespace MyStore.Tests
{
    public class ProductServiceTests
    {
        //private readonly MockProductService mockProductService;

        //public ProductServiceTests(MockProductService mockProductService)
        //{
        //    this.mockProductService = mockProductService;
        //}



        private readonly Mock<IProductRepository> mockProductRepository;
        private readonly IMapper mapper;

        public ProductServiceTests()
        {
            mockProductRepository = new Mock<IProductRepository>();
            mapper = new MapperConfiguration(cfg =>
             {
                 cfg.AddProfile(new ProductProfile());
             }).CreateMapper();
        }

        [Fact]
        public void Should_Return_ListOfProductModel_On_GetALL()
        {
            //arrange
            mockProductRepository.Setup(x => x.GetAll())
                .Returns(new List<Product> { new Product() { } });

            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile(new ProductProfile());
            //});
            //var mapper = config.CreateMapper();


            var service = new ProductService(mockProductRepository.Object, mapper);

            //act
            var response = service.GetAllProducts();

            //assert
            Assert.IsType<List<ProductModel>>(response.ToList());

        }

        [Fact]
        public void Should_Return_AllProducts()
        {
            //arrange
            mockProductRepository.Setup(x => x.GetAll())
                .Returns(MultipleProducts());

            var service = new ProductService(mockProductRepository.Object, mapper);

            //act
            var response = service.GetAllProducts();

            //assert
            Assert.Equal(MultipleProducts().Count(), response.Count());
            Assert.IsType<List<ProductModel>>(response as IEnumerable<ProductModel>);
        }

        [Fact]
        public void Shoul_Return_OneProduct_On_GetById()
        {
            //arrange
            mockProductRepository.Setup(x => x.GetByID(ProductConsts.Product1Id))
             .Returns(ReturnOneProduct(ProductConsts.Product1Id));

            var service = new ProductService(mockProductRepository.Object, mapper);    

            //act
            var response = service.GetByID(ProductConsts.Product1Id);

  
            //assert

            Assert.IsType<ProductModel>(response);
            Assert.Equal(ProductConsts.Product1Id, response.Productid);

        }

        [Fact]
        public void Shoul_Return_ProductModel_On_Post()
        {
            //arrange
            mockProductRepository.Setup(x => x.Add(It.IsAny<Product>()))
            .Returns(ReturnOneProduct(ProductConsts.Product1Id));

            var service = new ProductService(mockProductRepository.Object, mapper);

            //act
            var response = service.AddProduct(ReturnOneProductModel());

            //assert
            Assert.IsType<ProductModel>(response);
            Assert.Equal(ProductConsts.ProductName1, response.Productname);
        }

        [Fact]
        public void ShouldReturn_Model_On_Put()
        {
            //arrange
            mockProductRepository.Setup(x => x.Update(ReturnOneProduct(ProductConsts.Product1Id)))
            .Returns(ReturnOneProduct(ProductConsts.Product1Id));

            var service = new ProductService(mockProductRepository.Object, mapper);
            mockProductRepository.Setup(x => x.Update(It.IsAny<Product>())).Returns(ReturnOneProduct(ProductConsts.Product1Id));

            //act
            var response = service.UpdateProduct(ReturnOneProductModel());

            //asert
            Assert.Equal(ProductConsts.ProductName1, response.Productname);
            Assert.IsType<ProductModel>(response);

        }

        [Fact]
        public void ShouldReturn_True_On_Delete()
        {
            //arrange
            mockProductRepository.Setup(x => x.Delete(ReturnOneProduct(ProductConsts.Product1Id)))
            .Returns(true);

            var service = new ProductService(mockProductRepository.Object, mapper);
            mockProductRepository.Setup(x => x.Delete(It.IsAny<Product>())).Returns(true);
            mockProductRepository.Setup(x => x.GetByID(It.IsAny<int>())).Returns(ReturnOneProduct(1));

            //act
            var response = service.Delete(ProductConsts.Product1Id);

            // Assert
            Assert.True(response);

        }

        private Product ReturnOneProduct(int i)
        {
            IEnumerable<Product> product = MultipleProducts();
            return product.Where(x => x.Productid == i).FirstOrDefault();
        }

        private ProductModel ReturnOneProductModel()
        {
            ProductModel model = new ProductModel
            {
                Productid = ProductConsts.Product1Id,
                Productname = ProductConsts.ProductName1,
                Categoryid = (int)CategoryConsts.Categories.Condiments,
                Supplierid = CustomerSupplierConsts.SupplierId,
                Unitprice = ProductConsts.UnitPriceTest,
                Discontinued = ProductConsts.DiscontinuedTest
            };

            return model;
        }

        private List<Product> MultipleProducts()
        {
            return new List<Product>()
            {
                new Product
                {
                    Productid = ProductConsts.Product1Id,
                    Productname = ProductConsts.ProductName1,
                    Categoryid = (int)CategoryConsts.Categories.Condiments,
                    Supplierid = CustomerSupplierConsts.SupplierId,
                    Unitprice = ProductConsts.UnitPriceTest,
                    Discontinued = ProductConsts.DiscontinuedTest
                },
                new Product
                {
                    Productid = ProductConsts.Product2Id,
                    Productname = ProductConsts.ProductName2,
                    Categoryid = (int)CategoryConsts.Categories.Confections,
                    Supplierid = CustomerSupplierConsts.SupplierId2,
                    Unitprice = ProductConsts.UnitPriceTest,
                    Discontinued = ProductConsts.DiscontinuedTest
                },
                new Product
                {
                    Productid = ProductConsts.Product3Id,
                    Productname = ProductConsts.ProductName3,
                    Categoryid = (int)CategoryConsts.Categories.Dairy,
                    Supplierid = CustomerSupplierConsts.SupplierId,
                    Unitprice = ProductConsts.UnitPriceTest,
                    Discontinued = ProductConsts.DiscontinuedTest
                }
            };
        }
    }
}

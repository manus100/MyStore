﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MyStore.Controllers;
using MyStore.Models;
using MyStore.Services;
using Xunit;

namespace MyStore.Tests
{
    public class ProductControllerTests
    {
        private readonly Mock<IProducService> mockProductService;

        public ProductControllerTests()
        {
            mockProductService = new Mock<IProducService>();
        }

        [Fact]
        public void Should_Return_Ok_On_GetAll()
        {
            //arrange
            mockProductService.Setup(x => x.GetAllProducts())
                .Returns(new List<ProductModel> { new ProductModel() { } });

            var controller = new ProductsController(mockProductService.Object);

            //act
            var response = controller.Get();

            var result = response.Result as OkObjectResult;
            var actualData = result.Value as IEnumerable<ProductModel>;

            //assert
            Assert.IsType<OkObjectResult>(result);

            Assert.IsType<List<ProductModel>>(actualData);

        }

        [Fact]
        public void Should_Return_AllProducts()
        {
            //arrange
            mockProductService.Setup(x => x.GetAllProducts())
                .Returns(MultipleProducts());

            var controller = new ProductsController(mockProductService.Object);

            //act
            var response = controller.Get();

            var result = response.Result as OkObjectResult;
            var actualData = result.Value as IEnumerable<ProductModel>;

            //assert
            Assert.Equal(MultipleProducts().Count(), actualData.Count());
        }


        [Fact]
        public void Shoul_Return_Ok_On_GetById()
        {
            //arrange
            mockProductService.Setup(x => x.GetByID(Consts.ProductIDTest2))
                .Returns(MultipleProducts()[Consts.ProductIDTest2 - 1]);

            var controller = new ProductsController(mockProductService.Object);

            //act
            var response = controller.Get(Consts.ProductIDTest2);

            var result = response.Result as OkObjectResult;
            var actualData = result.Value as ProductModel;

            //assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<ProductModel>(actualData);

        }

        [Fact]
        public void ShouldReturn_ProductID()
        {
            //arrange
            mockProductService.Setup(x => x.GetByID(Consts.ProductIDTest2))
                .Returns(MultipleProducts()[Consts.ProductIDTest2 - 1]);

            var controller = new ProductsController(mockProductService.Object);

            //act
            var response = controller.Get(Consts.ProductIDTest2);

            var result = response.Result as OkObjectResult;
            var actualData = result.Value as ProductModel;

            //assert
            Assert.Equal(Consts.ProductIDTest2, actualData.Productid);

        }

        [Fact]
        public void Shoul_Return_Created_On_Post()
        {
            //arrange

            mockProductService.Setup(x => x.AddProduct(It.IsAny<ProductModel>())).Returns(ProductToInsert());

            var controller = new ProductsController(mockProductService.Object);

            //act
            var response = controller.Post(ProductToInsert());
            var result = response.Result as CreatedAtActionResult;
            var actualData = result.Value as ProductModel;

            //assert
            Assert.IsType<CreatedAtActionResult>(result);
            Assert.IsType<ProductModel>(actualData); ;
            // Assert.Equal(4, actualData.Supplierid);
            //  Assert.Equal("Product Test 1", actualData.Productname);

        }

        [Fact]
        public void ShouldReturn_Ok_On_Put()
        {
            ProductModel model = new ProductModel
            {
                Productid = Consts.ProductIDTest1,
                Productname = Consts.ProductNameTest1,
                Categoryid = (int)Consts.Categories.Condiments,
                Supplierid = Consts.SupplierIDTest,
                Unitprice = Consts.UnitPriceTest,
                Discontinued = Consts.DiscontinuedTest
            };

            //arrange
            mockProductService.Setup(x => x.UpdateProduct(It.IsAny<ProductModel>())).Returns(model);
            mockProductService.Setup(x => x.Exists(Consts.ProductIDTest1)).Returns(true);
            mockProductService.Setup(x => x.CheckPrice(model)).Returns(true);

            var controller = new ProductsController(mockProductService.Object);

            //act
            var response = controller.Put(Consts.ProductIDTest1, model);

            var result = response.Result as OkObjectResult;
            var actualData = result.Value as ProductModel;

            //assert
            Assert.IsType<OkObjectResult>(result);

        }


        [Fact]
        public void ShouldReturn_NoContent_On_Delete()
        {
            ////arrange
            mockProductService.Setup(x => x.Delete(MultipleProducts()[1].Productid)).Returns(true);
            mockProductService.Setup(x => x.Exists(MultipleProducts()[1].Productid)).Returns(true);


            // Arrange
            var controller = new ProductsController(mockProductService.Object);

            // Act
            var result = controller.Delete(MultipleProducts()[1].Productid);


            // Assert
            Assert.IsType<NoContentResult>(result);

        }

        private ProductModel ProductToInsert()
        {
            return new ProductModel
            {
                Productname = Consts.ProductNameTest1,
                Supplierid = Consts.SupplierIDTest,
                Categoryid =(int)Consts.Categories.Condiments,
                Unitprice = Consts.UnitPriceTest,
                Discontinued = Consts.DiscontinuedTest
            };
        }

        private List<ProductModel> MultipleProducts()
        {
            return new List<ProductModel>()
            {
                new ProductModel
                {
                    Productid = Consts.ProductIDTest1,
                    Productname = Consts.ProductNameTest1,
                    Categoryid = (int)Consts.Categories.Condiments,
                    Supplierid = Consts.SupplierIDTest,
                    Unitprice = Consts.UnitPriceTest,
                    Discontinued = Consts.DiscontinuedTest
                },
                new ProductModel
                {
                    Productid = Consts.ProductIDTest2,
                    Productname = Consts.ProductNameTest2,
                    Categoryid = (int)Consts.Categories.Confections,
                    Supplierid = Consts.SupplierIDTest,
                    Unitprice = Consts.UnitPriceTest,
                    Discontinued = Consts.DiscontinuedTest
                },
                new ProductModel
                {
                    Productid = Consts.ProductIDTest3,
                    Productname = Consts.ProductNameTest3,
                    Categoryid = (int)Consts.Categories.Dairy,
                    Supplierid = Consts.SupplierIDTest,
                    Unitprice = Consts.UnitPriceTest,
                    Discontinued = Consts.DiscontinuedTest
                }
            };
        }
    }
}

//private List<ProductModel> MultipleProducts()
//        {
//            return new List<ProductModel>()
//            {
//                new ProductModel
//                {
//                    Categoryid= (int)Consts.Categories.Condiments,
//                    Productid=Consts.TestProductID,
//                    Productname= Consts.productName,
//                    Discontinued=false,
//                    Unitprice=Consts.TestUnitPrice,
//                    Supplierid=Consts.TestSupplierID
//                },
//                 new ProductModel
//                {
//                    Categoryid=2,
//                    Productid=3,
//                    Productname="Product 2",
//                    Discontinued=false,
//                    Unitprice=4,
//                    Supplierid=4
//                },
//                   new ProductModel
//                {
//                    Categoryid=2,
//                    Productid=3,
//                    Productname="Product 3",
//                    Discontinued=false,
//                    Unitprice=4,
//                    Supplierid=4
//                }
//            };
//        }



//    }
//}

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
    public class ProductRepositoryTests
    {
        private readonly Mock<IProductRepository> mockRepo;
        public ProductRepositoryTests()
        {
            mockRepo = new Mock<IProductRepository>();
        }

        [Fact]
        public void Should_GetAllProducts()
        {
            //arrange
            mockRepo.Setup(repo => repo.GetAll())    //setup => ii zic ce sa returneze si din ce
                    .Returns(ReturnMultiple());

            //act
            var result = mockRepo.Object.GetAll();   //instanta dummy pe care si-o face el si de pe care pot apela metode care sunt in repository-ul meu

            //assert
            Assert.Equal(3, result.Count());

            Assert.IsType<List<Product>>(result);

        }

        [Fact]
        public void Should_GetOneProduct()
        {
            //arrange
            mockRepo.Setup(repo => repo.GetByID(ProductConsts.Product1Id))
                .Returns(ReturnOneProduct(ProductConsts.Product1Id));

            //act
            var result = mockRepo.Object.GetByID(ProductConsts.Product1Id);

            //asert
            Assert.Equal(ProductConsts.Product1Id, result.Productid);
            Assert.IsType<Product>(result);

        }

        [Fact]
        public void Shoul_Return_Product_On_Post()
        {
            //arrange
            mockRepo.Setup(repo => repo.Add(It.IsAny<Product>()))
                .Returns(ReturnOneProduct(ProductConsts.Product1Id));

            //act
            var result = mockRepo.Object.Add(ReturnOneProduct(ProductConsts.Product1Id));

            //asert
            Assert.Equal(ProductConsts.ProductName1, result.Productname);
            Assert.IsType<Product>(result);

        }

        [Fact]
        public void ShouldReturn_Product_On_Put()
        {
            //arrange
            mockRepo.Setup(repo => repo.Update(It.IsAny<Product>()))
                .Returns(ReturnOneProduct(ProductConsts.Product1Id));

            //act
            var result = mockRepo.Object.Update(ReturnOneProduct(ProductConsts.Product1Id));

            //asert
            Assert.Equal(ProductConsts.ProductName1, result.Productname);
            Assert.IsType<Product>(result);
        }

        [Fact]
        public void Shoul_Return_True_On_Delete()
        {
            //arrange
            mockRepo.Setup(repo => repo.Delete(It.IsAny<Product>()))
                .Returns(true);

            //act
            var result = mockRepo.Object.Delete(ReturnOneProduct(ProductConsts.Product1Id));

            //asert
            Assert.True(result);

        }

        private Product ReturnOneProduct(int i)
        {
            IEnumerable<Product> products = ReturnMultiple();
            return products.Where(x => x.Productid == i).FirstOrDefault();
        }

        private static List<Product> ReturnMultiple()
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

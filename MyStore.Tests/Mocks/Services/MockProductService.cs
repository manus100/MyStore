using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStore.Models;
using MyStore.Services;
using Moq;
using MyStore.Domain.Entities;

namespace MyStore.Tests.Mocks.Services
{
   public class MockProductService:Mock<IProducService>
    {
        public MockProductService MockGetAllProducts(List<ProductModel> results)
        {
            Setup(x => x.GetAllProducts()).Returns(results);

            return this;
        }

        public MockProductService MockGetByID(ProductModel product)
        {
            Setup(x => x.GetByID(It.IsAny<int>()))
                .Returns(product);
                //.Throws(new Exception("Product with ID not found"));
            return this;
        }
    }
}

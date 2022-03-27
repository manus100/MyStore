using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MyStore.Models;
using MyStore.Services;

namespace MyStore.Tests.Mocks.Services
{
    public class MockCategoryService : Mock<ICategoryService>
    {
        public MockCategoryService MockGetAllCategories(List<CategoryModel> results)
        {
            Setup(x => x.GetAll()).Returns(results);

            return this;
        }


        public MockCategoryService MockGetByID(CategoryModel category)
        {
            Setup(x => x.GetByID(It.IsAny<int>()))
                .Returns(category);

            return this;
        }

 


    }
}

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
    public class MockEmployeeService : Mock<IEmployeeService>
    {
        public MockEmployeeService MockGetAllEmployees(List<EmployeeModel> results)
        {
            Setup(x => x.GetAll()).Returns(results);

            return this;
        }

        public MockEmployeeService MockGetByID(EmployeeModel employee)
        {
            Setup(x => x.GetByID(It.IsAny<int>()))
                .Returns(employee);

            return this;
        }
    }
}
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
    public class EmployeeRepositoryTests
    {
        [Fact]
        public void Should_GetAllEmployees()
        {
            //arrange
            var mocRepo = new Mock<IEmployeeRepository>();
            mocRepo.Setup(repo => repo.GetAll())
                .Returns(ReturnMultiple());

            //act
            var result = mocRepo.Object.GetAll();

            //asert
            Assert.Equal(2, result.Count());
            Assert.IsType<List<Employee>>(result);

        }

        private List<Employee> ReturnMultiple()
        {
            return new List<Employee>()
                 {
                    new Employee
                    {
                        Empid = Consts.EmpIDTest1,
                        Lastname = Consts.LastNameTest1,
                        Firstname = Consts.FirstNameTest1,
                        Title = Consts.Title,
                        Titleofcourtesy = Consts.Titleofcourtesy,
                        Birthdate = Consts.BirthDate,
                        Hiredate = Consts.HireDate,
                        Address = Consts.Address,
                        City = Consts.City,
                        Region = Consts.Region,
                        Country = Consts.Country,
                        Phone = Consts.Phone,
                        Mgrid = Consts.MgrID
                    },
                    new Employee
                    {
                        Empid = Consts.EmpIDTest2,
                        Lastname = Consts.LastNameTest2,
                        Firstname = Consts.FirstNameTest2,
                        Title = Consts.Title,
                        Titleofcourtesy = Consts.Titleofcourtesy,
                        Birthdate = Consts.BirthDate,
                        Hiredate = Consts.HireDate,
                        Address = Consts.Address,
                        City = Consts.City,
                        Region = Consts.Region,
                        Country = Consts.Country,
                        Phone = Consts.Phone,
                        Mgrid = Consts.MgrID
                    } };
        }
    }

}
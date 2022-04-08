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
        private Mock<IEmployeeRepository> mockRepo;
        public EmployeeRepositoryTests()
        {
            mockRepo = new Mock<IEmployeeRepository>();
        }

        [Fact]
        public void Should_GetAllEmployees()
        {
            //arrange
            mockRepo.Setup(repo => repo.GetAll())
                .Returns(ReturnMultiple());

            //act
            var result = mockRepo.Object.GetAll();

            //asert
            Assert.Equal(2, result.Count());
            Assert.IsType<List<Employee>>(result);

        }

        [Fact]
        public void Should_GetOneEmployee()
        {
            //arrange
            mockRepo.Setup(repo => repo.GetByID(EmployeeConsts.EmpId))
                .Returns(ReturnOneEmployee(EmployeeConsts.EmpId));

            //act
            var result = mockRepo.Object.GetByID(EmployeeConsts.EmpId);

            //asert
            Assert.Equal(EmployeeConsts.EmpId, result.Empid);
            Assert.IsType<Employee>(result);

        }

        [Fact]
        public void Shoul_Return_Employee_On_Post()
        {
            //arrange
            mockRepo.Setup(repo => repo.Add(It.IsAny<Employee>()))
                .Returns(ReturnOneEmployee(EmployeeConsts.EmpId));

            //act
            var result = mockRepo.Object.Add(ReturnOneEmployee(EmployeeConsts.EmpId));

            //asert
            Assert.Equal(EmployeeConsts.FirstName1, result.Firstname);
            Assert.IsType<Employee>(result);

        }

        [Fact]
        public void ShouldReturn_Employee_On_Put()
        {
            //arrange
            mockRepo.Setup(repo => repo.Update(It.IsAny<Employee>()))
                .Returns(ReturnOneEmployee(EmployeeConsts.EmpId));

            //act
            var result = mockRepo.Object.Update(ReturnOneEmployee(EmployeeConsts.EmpId));

            //asert
            Assert.Equal(EmployeeConsts.FirstName1, result.Firstname);
            Assert.IsType<Employee>(result);

        }

        [Fact]
        public void Shoul_Return_True_On_Delete()
        {
            //arrange
            mockRepo.Setup(repo => repo.Delete(It.IsAny<Employee>()))
                .Returns(true);

            //act
            var result = mockRepo.Object.Delete(ReturnOneEmployee(EmployeeConsts.EmpId));

            //asert
            Assert.True(result);

        }


        private Employee ReturnOneEmployee(int i)
        {
            IEnumerable<Employee> employees = ReturnMultiple();
            return employees.Where(x => x.Empid == i).FirstOrDefault();
        }

        private List<Employee> ReturnMultiple()
        {
            return new List<Employee>()
                 {
                    new Employee
                    {
                        Empid = EmployeeConsts.EmpId,
                        Lastname = EmployeeConsts.LastName1,
                        Firstname = EmployeeConsts.FirstName1,
                        Title = EmployeeConsts.Title,
                        Titleofcourtesy = EmployeeConsts.Titleofcourtesy,
                        Birthdate = EmployeeConsts.BirthDate,
                        Hiredate = EmployeeConsts.HireDate,
                        Address = EmployeeConsts.Address,
                        City = EmployeeConsts.City,
                        Region = EmployeeConsts.Region,
                        Country = EmployeeConsts.Country,
                        Phone = EmployeeConsts.Phone,
                        Mgrid = EmployeeConsts.MgrID
                    },
                    new Employee
                    {
                        Empid = EmployeeConsts.EmpId2,
                        Lastname = EmployeeConsts.LastName2,
                        Firstname = EmployeeConsts.FirstName2,
                        Title = EmployeeConsts.Title,
                        Titleofcourtesy = EmployeeConsts.Titleofcourtesy,
                        Birthdate = EmployeeConsts.BirthDate,
                        Hiredate = EmployeeConsts.HireDate,
                        Address = EmployeeConsts.Address,
                        City = EmployeeConsts.City,
                        Region = EmployeeConsts.Region,
                        Country = EmployeeConsts.Country,
                        Phone = EmployeeConsts.Phone,
                        Mgrid = EmployeeConsts.MgrID
                    } };
        }
    }

}
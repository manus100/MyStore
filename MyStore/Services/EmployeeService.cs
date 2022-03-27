using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Models;

namespace MyStore.Services
{
    public interface IEmployeeService
    {
        EmployeeModel Add(EmployeeModel model);
        bool Delete(int id);
        bool Exists(int id);
        IEnumerable<EmployeeModel> GetAll();
        EmployeeModel GetByID(int id);
        bool HasSubordinates(int id);
        EmployeeModel Update(EmployeeModel employeeToUpdate);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        public IEnumerable<EmployeeModel> GetAll()
        {
            var allEmployees = employeeRepository.GetAll();

            return mapper.Map<IEnumerable<EmployeeModel>>(allEmployees);
        }

        public EmployeeModel GetByID(int id)
        {
            return mapper.Map<EmployeeModel>(employeeRepository.GetByID(id));
        }

        public EmployeeModel Add(EmployeeModel model)
        {
            Employee newEmployee = mapper.Map<Employee>(model);
            var addedEmployee = employeeRepository.Add(newEmployee);

            return mapper.Map <EmployeeModel>(addedEmployee);

        }

        public EmployeeModel Update(EmployeeModel employeeToUpdate)
        {
            var updatedEmployee = employeeRepository.Update(mapper.Map<Employee>(employeeToUpdate));
            return mapper.Map<EmployeeModel>(updatedEmployee);
        }

        public bool Exists(int id)
        {
            return employeeRepository.Exists(id);
        }

        public bool Delete(int id)
        {
            var itemToDelete = employeeRepository.GetByID(id);

            if (itemToDelete == null)
            {
                //eroare
                return false;
            }
            return employeeRepository.Delete(itemToDelete);
        }

        public bool HasSubordinates(int id)
        {
            return employeeRepository.HasSubordinates(id);
        }
    }


}

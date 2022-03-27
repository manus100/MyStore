using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;

namespace MyStore.Data
{
    public interface IEmployeeRepository
    {
        Employee Add(Employee employee);
        bool Delete(Employee employee);
        bool Exists(int id);
        IEnumerable<Employee> GetAll();
        Employee GetByID(int id);
        bool HasSubordinates(int id);
        Employee Update(Employee employeeToUpdate);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly StoreContext context;

        public EmployeeRepository(StoreContext context)
        {
            this.context = context;
        }


        public IEnumerable<Employee> GetAll()
        {
            return context.Employees.ToList();
        }

        public Employee GetByID(int id)
        {
            return context.Employees.Find(id);
        }

        public Employee Add(Employee employee)
        {
            var newEmployee = context.Employees.Add(employee);
            context.SaveChanges();
            return newEmployee.Entity;
        }

        public Employee Update(Employee employeeToUpdate)
        {
            var updatedEmployee = context.Employees.Update(employeeToUpdate);
            context.SaveChanges();

            return updatedEmployee.Entity;
        }

        public bool Exists(int id)
        {
            var exists = context.Employees.Count(x => x.Empid == id);
            return (exists == 1);
        }

        public bool HasSubordinates(int id)
        {
            //testez daca are subordonati, in caz afirmativ fac stergerea
            var IsMgr = context.Employees.Count(x => x.Mgrid == id);
            return (IsMgr > 0);
        }


        public bool Delete(Employee employee)
        {
            var deletedItem = context.Employees.Remove(employee);
            context.SaveChanges();

            return deletedItem != null;
        }
    }

   
}

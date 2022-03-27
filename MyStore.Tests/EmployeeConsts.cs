using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Tests
{
    public class EmployeeConsts
    {
        public const int EmpId = 1;
        public const int EmpId2 = 2;
        public const string LastName1 = "Popescu";
        public const string FirstName1 = "Ion";
        public const string LastName2 = "Ionescu";
        public const string FirstName2 = "Dan";
        public const string Title = "Test title";
        public const string Titleofcourtesy = "Mr.";
        public const string Address = "Address test";
        public const string City = "New York";
        public const string Region = "Region test";
        public const string PostalCode = "PostalCode";
        public const string Country = "USA";
        public const string Phone = "Phone test";
        public const string Fax = "Fax test";
        public static DateTime BirthDate = new DateTime(2021, 1, 1);
        public static DateTime HireDate = new DateTime(2022, 1, 1);
        public static int? MgrID = 1;

        public const string LastNameRequiredMessage = "The Lastname field is required.";
    }
}

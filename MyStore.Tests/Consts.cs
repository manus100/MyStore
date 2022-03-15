using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Tests
{
    public static class Consts
    {
        public static int ShipperIDTest1 = 2;
        public static int ShipperIDTest2 = 3;
        public const string CategoryNameRequiredMessage = "The Categoryname field is required.";
        public const string CompanyNameRequiredMessage = "The Companyname field is required.";
        public const string LastNameRequiredMessage = "The Lastname field is required.";

        public const string ValidCategoryName = "New category";
        public const string ValidCategoryDescription = "Description for new category";
        public const string CompanyName = "Customer company name test";
        public const string ContactName = "Contact name test";
        public const string ContactTitle = "Contact title test";
        public const string Address = "Address test";
        public const string City = "New York";
        public const string Region = "Region test";
        public const string PostalCode = "PostalCode";
        public const string Country = "USA";
        public const string Phone = "Phone test";
        public const string Fax = "Fax test";

        public const int CustIDTest1 = 1;
        public const int CustIDTest2 = 2;
        public const int EmpIDTest1 = 1;
        public const int EmpIDTest2 = 2;
        public const string LastNameTest1 = "Popescu";
        public const string FirstNameTest1 = "Ion";
        public const string LastNameTest2 = "Ionescu";
        public const string FirstNameTest2 = "Dan";
        public const string Title = "Test title";
        public const string Titleofcourtesy = "Mr.";
        public static DateTime BirthDate = new DateTime(2021, 1, 1);
        public static DateTime HireDate = new DateTime(2022, 1, 1);
        public static int? MgrID = 1;

        public const string ShipperCompanyName = "Shipper company name test";
        public const string SupplierCompanyName = "Supplier company name test";

        public enum Categories
        {
            Beverages = 1,
            Condiments = 2,
            Confections = 3,
            Dairy = 4,
            Grains,
            Meat,
            Produce,
            Seafood
        }

        public const int ProductIDTest1 = 1;
        public const int ProductIDTest2 = 2;
        public const int ProductIDTest3 = 3;
        public const int CategoryIDTest1 = 1;
        public const int CategoryIDTest2 = 2;
        public const int SupplierIDTest1 = 4;
        public const int SupplierIDTest2 = 2;
        public static decimal UnitPriceTest = 100.23M;
        public const string ProductNameTest1 = "Product test 1";
        public const string ProductNameTest2 = "Product test 2";
        public const string ProductNameTest3 = "Product test 3";
        public const bool DiscontinuedTest = false;


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Tests
{
    public static class OrderConsts 
    { 
        public const int OrderId = 1; 
        public const int CustId = 1; 
        public const int EmpId = 1; 
        public const int ShipperId = 1; 
        public static DateTime Orderdate = new DateTime(2021, 08, 1); 
        public static DateTime Requireddate = new DateTime(2021, 10, 1); 
        public static DateTime? Shippeddate = new DateTime(2021, 11, 1); 
        public const decimal Freight = 17.5M; 
        public const string Shipname = "Shipper test"; 
        public const string Shipaddress = "Test Adress"; 
        public const string Shipcity = "Test City"; 
        public const string Shipregion = "Test Region"; 
        public const string Shippostalcode = "PostalCode"; 
        public const string Shipcountry = "Test Country"; 
    }
}

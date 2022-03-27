using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Domain.Entities
{
    public class CustomersOfAProduct
    {
        public int Productid { get; set; }
        public string Productname { get; set; }
        public int NumberOfCustomers { get; set; }
        public int TotalQtyOrdered { get; set; }
    }
}

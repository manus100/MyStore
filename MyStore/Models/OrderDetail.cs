using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Domain.Entities;

namespace MyStore.Models
{
    public class OrderDetail
    {
       
        public int Orderid { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        public int Productid { get; set; }
        public decimal Unitprice { get; set; }
        public short Qty { get; set; }
        public decimal Discount { get; set; }
    }
}

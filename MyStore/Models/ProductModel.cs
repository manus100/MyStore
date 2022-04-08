using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class ProductModel
    {
        //only relevant data
        [Required(ErrorMessage = "Productid field is required!")]
        public int Productid { get; set; }
       // [Required]
        [Required(ErrorMessage = "Product name is required!")]
        [StringLength(40, ErrorMessage = "Product name must be between 4 and 40 characters long.", MinimumLength = 4)]
        public string Productname { get; set; }
        [Required(ErrorMessage = "Supplierid field is required!")]
        public int Supplierid { get; set; }
        [Required(ErrorMessage = "Categoryid field is required!")]
        public int Categoryid { get; set; }
        [Required(ErrorMessage = "Unitprice field is required!")]
        public decimal Unitprice { get; set; }
        [Required(ErrorMessage = "Discontinued field is required!")]
        public bool Discontinued { get; set; }
    }
}

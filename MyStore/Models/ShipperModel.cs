using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class ShipperModel
    {
        public int Shipperid { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Company name must be between 9 and 40 characters long!", MinimumLength = 9)]
        [RegularExpression(@"^Shipper .*$", ErrorMessage = "Company name must start with Shipper ")]
        public string Companyname { get; set; }
        [Required]
        [StringLength(24, ErrorMessage = "Phone number cannot exceed 24 characters!")]
       
        public string Phone { get; set; }
    }
}

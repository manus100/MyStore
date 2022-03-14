using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class CustomerModel
    {
        public int Custid { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Company name must be between 9 and 40 characters long.", MinimumLength = 9)]
        [RegularExpression(@"^Customer .*$", ErrorMessage = "Company name must start with Customer ")]
        public string Companyname { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Contact name must be between 2 and 30 characters long.", MinimumLength = 2)]
        public string Contactname { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Contact title must be between 2 and 30 characters long.", MinimumLength = 2)]
        public string Contacttitle { get; set; }
        [Required]
        [StringLength(60, ErrorMessage = "Address field cannot exceed 60 characters!")]
        public string Address { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "City field cannot exceed 15 characters!")]
        public string City { get; set; }
        [StringLength(15, ErrorMessage = "Region field cannot exceed 15 characters!")]
        public string Region { get; set; }
        [StringLength(10, ErrorMessage = "Postal code field cannot exceed 10 characters!")]
        public string Postalcode { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Country field cannot exceed 15 characters!")]
        public string Country { get; set; }
        [Required]
        [StringLength(24, ErrorMessage = "Phone field cannot exceed 24 characters!")]
        public string Phone { get; set; }
        [StringLength(24, ErrorMessage = "Fax field cannot exceed 24 characters!")]
        public string Fax { get; set; }
    }
}

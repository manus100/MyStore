using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Models
{
   
    public class EmployeeModel
    {
        public int Empid { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Last name must be between 2 and 20 characters long.", MinimumLength = 2)]
        //[Display(Name = "Last Name", Order = -1,
        //Prompt = "Enter Last Name", Description = "Emp Last Name")]   //pentru UI
        public string Lastname { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "First name must be between 2 and 10 characters long.", MinimumLength = 2)]
        //[Display(Name = "First Name", Order = -2,
        //Prompt = "Enter First Name", Description = "Emp First Name")]
        public string Firstname { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Title field cannot exceed 30 characters!")]
        public string Title { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Title of courtesy field cannot exceed 25 characters!")]
        [RegularExpression("Mr.|Mrs.|Ms.|Dr.|Miss|Sir|Madam", ErrorMessage = "The title of courtesy must be one of the values: 'Mr.', 'Mrs.', 'Ms.','Dr.','Miss','Sir' or 'Madam' ")]
        public string Titleofcourtesy { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public DateTime Hiredate { get; set; }
        [Required]
        [StringLength(60, ErrorMessage = "Address field cannot exceed 60 characters!")]
        public string Address { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "City field cannot exceed 15 characters!")]
        public string City { get; set; }
        [StringLength(15, ErrorMessage = "Region field cannot exceed 15 characters!")]
        public string Region { get; set; }
        [StringLength(10, ErrorMessage = "Postal code cannot exceed 10 characters!")]
        public string Postalcode { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Country field cannot exceed 15 characters!")]
        public string Country { get; set; }
        [Required]
        [StringLength(24, ErrorMessage = "Phone field cannot exceed 24 characters!")]
        public string Phone { get; set; }
        public int? Mgrid { get; set; }

    }
}

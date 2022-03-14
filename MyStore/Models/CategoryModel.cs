using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class CategoryModel
    {
        public int Categoryid { get; set; }
        [Required]
       // [MinLength(2), MaxLength(15)]
        [StringLength(15, ErrorMessage = "Category name must be between 2 and 15 characters long.", MinimumLength = 2)]
        public string Categoryname { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Description field cannot exceed 200 characters!")]
        public string Description { get; set; }
    }
}

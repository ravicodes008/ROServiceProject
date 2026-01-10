using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ROServiceProject.Models
{
	public class ServiceManModel
	{
        public int ServiceManId { get; set; }

        [Required(ErrorMessage = "Service man name is required")]
        [Display(Name = "Service Man Name")]
        public string ServiceManName { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Mobile must be 10 digits")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid mobile number")]
        public string Mobile { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        public string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
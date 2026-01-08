using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ROServiceProject.Models
{
	public class UserLoginModel
	{
        [Required(ErrorMessage = "UserName is required")]
        [Display(Name = "Mobile Number")]
        public String UserName { get; set; }
       
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ROServiceProject.Models
{
	public class PartModel
	{
        public int PartId { get; set; }

        [Required]
        [Display(Name = "Part Code")]
        public string PartCode { get; set; }

        [Required]
        [Display(Name = "Part Name")]
        public string PartName { get; set; }

        public bool IsActive { get; set; }
    }
}
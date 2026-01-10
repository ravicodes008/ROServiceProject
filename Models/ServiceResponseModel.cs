using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ROServiceProject.Models
{
	public class ServiceResponseModel
	{
        public int ResponseId { get; set; }

        [Required]
        public int RequestId { get; set; }

        [Display(Name = "Parts Changed")]
        public string PartsChanged { get; set; }

        [Required(ErrorMessage = "Service details are required")]
        [Display(Name = "Service Details")]
        public string ServiceDetails { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [Display(Name = "Service Charge")]
        public decimal ServiceCharge { get; set; }

        [Display(Name = "Next Service Date")]
        [DataType(DataType.Date)]
        public DateTime? NextServiceDate { get; set; }

        [Display(Name = "Completed By")]
        public int CompletedBy { get; set; }

        public DateTime CompletedDate { get; set; }
    }
}
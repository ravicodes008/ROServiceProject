using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ROServiceProject.Models
{
	public class ServiceRequestModel
	{
        public int RequestId { get; set; }
        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string ProblemDescription { get; set; }

        public string RequestCode { get; set; }
        public string RequestStatus { get; set; }

        public int? AssignedTo { get; set; }
        public string AssignedToName { get; set; }

        public DateTime RequestDate { get; set; }
        public DateTime? AssignedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}
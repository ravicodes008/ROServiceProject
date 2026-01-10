using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ROServiceProject.Models
{
	public class CustomerModel
	{
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ROServiceProject.Models
{
	public class DashboardModel
	{
        public int TotalRequests { get; set; }
        public int PendingRequests { get; set; }
        public int AssignedRequests { get; set; }
        public int CompletedRequests { get; set; }
    }
}
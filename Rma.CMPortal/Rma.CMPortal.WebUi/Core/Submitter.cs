using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rma.CMPortal.WebUi.Core
{

    	public class Submitter
	{
		public int SubmitterId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string DisplayName { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool Active { get; set; }

        public Submitter()
		{
            DateUpdated = DateTime.Today;
		}
	}
}
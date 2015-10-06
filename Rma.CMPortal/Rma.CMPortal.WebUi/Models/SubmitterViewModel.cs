using System;
using System.Collections.Generic;
using Heroic.AutoMapper;
using Rma.CMPortal.WebUi.Core;

namespace Rma.CMPortal.WebUi.Models
{
    public class SubmitterViewModel : IMapFrom<Submitter>
	{
        public int SubmitterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool Active { get; set; }

        //public IList<CustomerOpportunityViewModel> Opportunities { get; set; }

        //public IList<CustomerRiskViewModel> Risks { get; set; }
	}
}
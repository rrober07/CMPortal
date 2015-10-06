using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rma.CMPortal.WebUi.Core
{
    public class Score
    {
        public int Id { get; set; }
        public string DR_ { get; set; }
        public int ProjectId { get; set; }
        public int SubmitterId { get; set; }
        public Nullable<decimal> Score1 { get; set; }
        public Nullable<System.DateTime> DeploymentDate { get; set; }
        public System.DateTime DateUpdated { get; set; }
    }
}
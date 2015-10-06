using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rma.CMPortal.WebUi.Core
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public System.DateTime DateUpdated { get; set; }
        public bool Active { get; set; }
    }
}
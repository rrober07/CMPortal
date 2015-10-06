using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Rma.CMPortal.WebUi.Core
{
    public class ConferenceCall
    {
        public int ConferenceCallsId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PinCode { get; set; }
        public System.DateTime DateUpdated { get; set; }
        public bool Active { get; set; }
    }
}
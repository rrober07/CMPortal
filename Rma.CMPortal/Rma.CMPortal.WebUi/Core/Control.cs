using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rma.CMPortal.WebUi.Core
{
    public class Control
    {
        public int Id { get; set; }
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public string Value { get; set; }
        public bool Exclude { get; set; }
        public Nullable<System.DateTime> ExcludeDate { get; set; }
    }
}
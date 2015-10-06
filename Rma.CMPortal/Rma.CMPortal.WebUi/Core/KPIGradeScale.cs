using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rma.CMPortal.WebUi.Core
{
    public class KPIGradeScale
    {
        public int Id { get; set; }
        public Nullable<decimal> LowBound { get; set; }
        public Nullable<decimal> HighBound { get; set; }
        public string LetterGrade { get; set; }
        public string Description { get; set; }
    }
}
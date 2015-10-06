namespace Rma.CMPortal.WebUi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KPIGradeScale")]
    public partial class KPIGradeScale
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public decimal? LowBound { get; set; }

        public decimal? HighBound { get; set; }

        [StringLength(10)]
        public string LetterGrade { get; set; }

        [StringLength(50)]
        public string Description { get; set; }
    }
}

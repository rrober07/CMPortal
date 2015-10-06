namespace Rma.CMPortal.WebUi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Control")]
    public partial class Control
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string TableName { get; set; }

        public string FieldName { get; set; }

        public string Value { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool Exclude { get; set; }

        public DateTime? ExcludeDate { get; set; }
    }
}

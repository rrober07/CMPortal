namespace Rma.CMPortal.WebUi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Score
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column("DR#")]
        [StringLength(50)]
        public string DR_ { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProjectId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubmitterId { get; set; }

        [Column("Score")]
        public decimal? Score1 { get; set; }

        public DateTime? DeploymentDate { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime DateUpdated { get; set; }
    }
}

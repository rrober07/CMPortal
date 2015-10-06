namespace Rma.CMPortal.WebUi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Submitter
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubmitterId { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        public string DisplayName { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime DateUpdated { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool Active { get; set; }
    }
}

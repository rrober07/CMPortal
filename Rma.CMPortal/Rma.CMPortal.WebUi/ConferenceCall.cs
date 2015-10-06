namespace Rma.CMPortal.WebUi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ConferenceCall
    {
        [Key]
        [Column(Order = 0)]
        public int ConferenceCallsId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PinCode { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime DateUpdated { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool Active { get; set; }
    }
}

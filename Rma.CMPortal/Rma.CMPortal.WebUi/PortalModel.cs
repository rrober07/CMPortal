namespace Rma.CMPortal.WebUi
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PortalModel : DbContext
    {
        public PortalModel()
            : base("name=PortalModel")
        {
        }

        public virtual DbSet<ConferenceCall> ConferenceCalls { get; set; }
        public virtual DbSet<Control> Controls { get; set; }
        public virtual DbSet<KPIGradeScale> KPIGradeScales { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Score> Scores { get; set; }
        public virtual DbSet<Submitter> Submitters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KPIGradeScale>()
                .Property(e => e.LowBound)
                .HasPrecision(6, 4);

            modelBuilder.Entity<KPIGradeScale>()
                .Property(e => e.HighBound)
                .HasPrecision(7, 4);

            modelBuilder.Entity<KPIGradeScale>()
                .Property(e => e.LetterGrade)
                .IsFixedLength();

            modelBuilder.Entity<KPIGradeScale>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Score>()
                .Property(e => e.Score1)
                .HasPrecision(5, 2);
        }
    }
}

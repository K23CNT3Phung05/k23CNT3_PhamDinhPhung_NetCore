using System;
using Microsoft.EntityFrameworkCore;

namespace PhamDinhPhung_2310900083.Models
{
    public partial class PhamDinhPhung2310900083Context : DbContext
    {
        public PhamDinhPhung2310900083Context()
        {
        }

        public PhamDinhPhung2310900083Context(DbContextOptions<PhamDinhPhung2310900083Context> options)
            : base(options)
        {
        }

        public virtual DbSet<PdpEmployee> PdpEmployees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PdpEmployee>(entity =>
            {
                entity.HasKey(e => e.PdpEmpId).HasName("PK_PdpEmployee");

                entity.ToTable("PdpEmployee");

                entity.Property(e => e.PdpEmpId).HasColumnName("PdpEmpId");

                entity.Property(e => e.PdpEmpName)
                    .HasMaxLength(100)
                    .HasColumnName("PdpEmpName");

                entity.Property(e => e.PdpEmpLevel)
                    .HasMaxLength(50)
                    .HasColumnName("PdpEmpLevel");

                entity.Property(e => e.PdpEmpStartDate)
                    .HasColumnName("PdpEmpStartDate");

                entity.Property(e => e.PdpEmpStatus)
                    .HasColumnName("PdpEmpStatus");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PdpLesson10.Models;

public partial class PdpK23cnt3lesson10DbContext : DbContext
{
    public PdpK23cnt3lesson10DbContext()
    {
    }

    public PdpK23cnt3lesson10DbContext(DbContextOptions<PdpK23cnt3lesson10DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PdpPosts> PdpPosts { get; set; }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //   => optionsBuilder.UseSqlServer("Server=07092005PP;Database=PdpK23CNT3Lesson10Db;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PdpPosts>(entity =>
        {
            entity.HasKey(e => e.PdpId);

            entity.ToTable("PdpPosts");

            entity.Property(e => e.PdpId).HasColumnName("PdpId");
            entity.Property(e => e.PdpContent)
                .HasColumnType("ntext")
                .HasColumnName("PdpContent");
            entity.Property(e => e.PdpImage)
                .HasMaxLength(250)
                .HasColumnName("PdpImage");
            entity.Property(e => e.PdpStatus).HasColumnName("PdpStatus");
            entity.Property(e => e.PdpTitle)
                .HasMaxLength(250)
                .HasColumnName("PdpTitle");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
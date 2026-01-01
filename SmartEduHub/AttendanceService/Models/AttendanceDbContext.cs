using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AttendanceService.Models;

public partial class AttendanceDbContext : DbContext
{
    public AttendanceDbContext()
    {
    }

    public AttendanceDbContext(DbContextOptions<AttendanceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<College> Colleges { get; set; }

    public virtual DbSet<Student> Students { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__Attendan__8B69261C9026876C");

            entity.ToTable("Attendance");

            entity.Property(e => e.Remarks).HasMaxLength(200);
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.College).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.CollegeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendanc__Colle__6754599E");

            entity.HasOne(d => d.Student).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendanc__Stude__68487DD7");
        });

        modelBuilder.Entity<College>(entity =>
        {
            entity.HasKey(e => e.CollegeId).HasName("PK__Colleges__29409539FB888BDB");

            entity.HasIndex(e => e.CollegeCode, "UQ__Colleges__F713DAB66C158982").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.CollegeCode).HasMaxLength(50);
            entity.Property(e => e.CollegeName).HasMaxLength(200);
            entity.Property(e => e.ContactEmail).HasMaxLength(100);
            entity.Property(e => e.ContactPhone).HasMaxLength(20);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52B99500E99A5");

            entity.HasIndex(e => e.AdmissionNo, "UQ__Students__C97E271142F9A79D").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.AdmissionNo).HasMaxLength(50);
            entity.Property(e => e.ContactInfo).HasMaxLength(200);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.ParentName).HasMaxLength(150);

            entity.HasOne(d => d.College).WithMany(p => p.Students)
                .HasForeignKey(d => d.CollegeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Students__Colleg__5DCAEF64");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

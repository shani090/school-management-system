using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExamService.Models;

public partial class ExamDbContext : DbContext
{
    public ExamDbContext()
    {
    }

    public ExamDbContext(DbContextOptions<ExamDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<College> Colleges { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Classes__CB1927C02DE4FDB9");

            entity.Property(e => e.ClassName).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Section).HasMaxLength(10);

            entity.HasOne(d => d.College).WithMany(p => p.Classes)
                .HasForeignKey(d => d.CollegeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Classes__College__5535A963");
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

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.ExamId).HasName("PK__Exams__297521C7329CC2F6");

            entity.Property(e => e.ExamName).HasMaxLength(100);

            entity.HasOne(d => d.Class).WithMany(p => p.Exams)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Exams__ClassId__6D0D32F4");

            entity.HasOne(d => d.College).WithMany(p => p.Exams)
                .HasForeignKey(d => d.CollegeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Exams__CollegeId__6B24EA82");

            entity.HasOne(d => d.Subject).WithMany(p => p.Exams)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Exams__SubjectId__6C190EBB");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__Results__976902086BE3F0D9");

            entity.Property(e => e.Grade).HasMaxLength(5);
            entity.Property(e => e.Remarks).HasMaxLength(200);

            entity.HasOne(d => d.College).WithMany(p => p.Results)
                .HasForeignKey(d => d.CollegeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Results__College__6FE99F9F");

            entity.HasOne(d => d.Exam).WithMany(p => p.Results)
                .HasForeignKey(d => d.ExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Results__ExamId__71D1E811");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subjects__AC1BA3A81A3CBCB1");

            entity.Property(e => e.SubjectName).HasMaxLength(100);

            entity.HasOne(d => d.Class).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Subjects__ClassI__59063A47");

            entity.HasOne(d => d.College).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.CollegeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Subjects__Colleg__5812160E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SIS.Models
{
    public partial class SISContext : DbContext
    {
        public SISContext()
        {
        }

        public SISContext(DbContextOptions<SISContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Instructor> Instructor { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudyTerm> StudyTerm { get; set; }
        public virtual DbSet<TeachingAssignment> TeachingAssignment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=SIS; User=SA; Password=ittselali91");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.Property(e => e.CourseId)
                    .HasColumnName("CourseID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Courses__Departm__5070F446");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.Property(e => e.InstructorId)
                    .HasColumnName("InstructorID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseId, e.TermId });

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.TermId).HasColumnName("TermID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Registrat__Cours__59FA5E80");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Registrat__Stude__5BE2A6F2");

                entity.HasOne(d => d.Term)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.TermId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Registrat__TermI__5AEE82B9");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<StudyTerm>(entity =>
            {
                entity.HasKey(e => e.TermId);

                entity.Property(e => e.TermId)
                    .HasColumnName("TermID")
                    .ValueGeneratedNever();

                entity.Property(e => e.TermEndDate).HasColumnType("datetime");

                entity.Property(e => e.TermStartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TeachingAssignment>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.InstructorId, e.TermId });

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.InstructorId).HasColumnName("InstructorID");

                entity.Property(e => e.TermId).HasColumnName("TermID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TeachingAssignment)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TeachingA__Cours__4D94879B");

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.TeachingAssignment)
                    .HasForeignKey(d => d.InstructorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TeachingA__Instr__4E88ABD4");

                entity.HasOne(d => d.Term)
                    .WithMany(p => p.TeachingAssignment)
                    .HasForeignKey(d => d.TermId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TeachingA__TermI__4F7CD00D");
            });
        }
    }
}

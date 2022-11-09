using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities;

public partial class SOPOContext : DbContext
{
    public SOPOContext()
    {
    }

    public SOPOContext(DbContextOptions<SOPOContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assignment> Assignments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Resident> Residents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SOPO5000;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Assignme__3214EC07BE384742");

            entity.ToTable("Assignment");

            entity.Property(e => e.EmployeeId)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Titel).HasMaxLength(100);

            entity.HasOne(d => d.Employee).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Assignment_Employee");

            entity.HasOne(d => d.Resident).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.ResidentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assignment_Resident");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07D84CE8DC");

            entity.ToTable("Employee");

            entity.Property(e => e.Id)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.ContactName).HasMaxLength(50);
            entity.Property(e => e.HireDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Resident>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Resident__3214EC07CD80F0FE");

            entity.ToTable("Resident");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public partial class ToDoDB : DbContext
{
    public ToDoDB()
    {
    }

    public ToDoDB(DbContextOptions<ToDoDB> options)
        : base(options)
    {
    }

    public virtual DbSet<Assignment> Assignment { get; set; }

    public virtual DbSet<AssignmentStatus> AssignmentStatus { get; set; }

    public virtual DbSet<Person> Person { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local);Database=ToDoDB;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PKAssignments");

            entity.Property(e => e.AssignmentDescription)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.AssignmentName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Person).WithMany(p => p.Assignment)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKPersonAssignmentPersonId");

            entity.HasOne(d => d.Status).WithMany(p => p.Assignment)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKAssignmentStatusAssignmentStatusId");
        });

        modelBuilder.Entity<AssignmentStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PKStatus");

            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PKPerson");

            entity.HasIndex(e => e.Email, "UQ__Person__A9D10534FC27F7BB").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

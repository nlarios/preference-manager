using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PreferenceManager.Infrastructure.Entities;

namespace PreferenceManager.Infrastructure.Context;

public partial class PmDbContext : DbContext
{
    public PmDbContext()
    {
    }

    public PmDbContext(DbContextOptions<PmDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; } = null!;
    public virtual DbSet<PersonPreference> PersonPreferences { get; set; } = null!;
    public virtual DbSet<Preference> Preferences { get; set; } = null!;
    public virtual DbSet<Solution> Solutions { get; set; } = null!;
    public virtual DbSet<SolutionPreference> SolutionPreferences { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseNpgsql(
                "Host=localhost:5432;Database=pm-db-local;Username=preference-manager;Password=preference-manager-pass");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum("person_type_t", new[] {"ADMIN", "SOLUTION_MANAGER", "CONSUMER"})
            .HasPostgresEnum("preference_type_t", new[] {"BOOLEAN", "INTEGER", "TEXT", "FlOAT"})
            .HasPostgresEnum("user_type_t", new[] {"ADMIN", "SOLUTION_MANAGER", "CONSUMER"});

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("person");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.ExternalAuthId)
                .HasMaxLength(255)
                .HasColumnName("external_auth_id");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<PersonPreference>(entity =>
        {
            entity.ToTable("person_preference");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.EncryptedValue)
                .HasMaxLength(255)
                .HasColumnName("encrypted_value")
                .HasDefaultValueSql("NULL::character varying");

            entity.Property(e => e.PersonId).HasColumnName("person_id");

            entity.Property(e => e.PreferenceId).HasColumnName("preference_id");

            entity.Property(e => e.PreferenceValue)
                .HasMaxLength(255)
                .HasColumnName("preference_value");

            entity.HasOne(d => d.Person)
                .WithMany(p => p.PersonPreferences)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_person_preference_person_id");

            entity.HasOne(d => d.Preference)
                .WithMany(p => p.PersonPreferences)
                .HasForeignKey(d => d.PreferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_person_preference_preference_id");
        });

        modelBuilder.Entity<Preference>(entity =>
        {
            entity.ToTable("preference");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.Property(e => e.Universal).HasColumnName("universal");
        });

        modelBuilder.Entity<Solution>(entity =>
        {
            entity.ToTable("solution");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Host)
                .HasMaxLength(255)
                .HasColumnName("host");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<SolutionPreference>(entity =>
        {
            entity.ToTable("solution_preference");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.PreferenceId).HasColumnName("preference_id");

            entity.Property(e => e.SolutionId).HasColumnName("solution_id");

            entity.HasOne(d => d.Preference)
                .WithMany(p => p.SolutionPreferences)
                .HasForeignKey(d => d.PreferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_solution_preference_preference_id");

            entity.HasOne(d => d.Solution)
                .WithMany(p => p.SolutionPreferences)
                .HasForeignKey(d => d.SolutionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_solution_preference_solution_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
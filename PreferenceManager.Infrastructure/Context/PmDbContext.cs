using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using PreferenceManager.Domain.Person;
using PreferenceManager.Domain.Preference;
using PreferenceManager.Infrastructure.Entities;
using Person = PreferenceManager.Infrastructure.Entities.Person;
using Preference = PreferenceManager.Infrastructure.Entities.Preference;
using PersonPreference = PreferenceManager.Infrastructure.Entities.PersonPreference;

namespace PreferenceManager.Infrastructure.Context;

public class PmDbContext : DbContext
{
    static PmDbContext()
    {
        NpgsqlConnection.GlobalTypeMapper.MapEnum<PreferenceType>();
        NpgsqlConnection.GlobalTypeMapper.MapEnum<PersonType>();
    }
    
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
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum("person_type", new[] {"ADMIN", "SOLUTION_MANAGER", "CONSUMER"})
            .HasPostgresEnum("preference_type", new[] {"BOOLEAN", "INTEGER", "TEXT", "FlOAT"});

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

            entity.Property(e => e.Type)
                .HasColumnName("person_type");
        });

        modelBuilder.Entity<PersonPreference>(entity =>
        {
            entity.ToTable("person_preference");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.EncryptedKey)
                .HasMaxLength(255)
                .HasColumnName("encrypted_key")
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

            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");

            entity.Property(e => e.Universal).HasColumnName("universal");

            entity.Property(e => e.Encrypted).HasColumnName("encrypted");

            entity.Property(e => e.Type)
                .HasColumnName("preference_type");
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
    }
}
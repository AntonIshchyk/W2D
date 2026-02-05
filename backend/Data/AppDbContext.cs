using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Backend.Models;

namespace Backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.ConfigureWarnings(warnings =>
            warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<UserActivity> UserActivities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Activity - Category relationship
        modelBuilder.Entity<Activity>()
            .HasOne(a => a.Category)
            .WithMany(c => c.Activities)
            .HasForeignKey(a => a.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Activity - Tag many-to-many relationship
        modelBuilder.Entity<Activity>()
            .HasMany(a => a.Tags)
            .WithMany(t => t.Activities)
            .UsingEntity(j => j.ToTable("ActivityTags"));

        // Tag unique name constraint
        modelBuilder.Entity<Tag>()
            .HasIndex(t => t.Name)
            .IsUnique();

        // Category unique name constraint
        modelBuilder.Entity<Category>()
            .HasIndex(c => c.Name)
            .IsUnique();

        // User unique email constraint
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        // UserActivity - User relationship
        modelBuilder.Entity<UserActivity>()
            .HasOne(s => s.User)
            .WithMany()
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // UserActivity - Activity relationship
        modelBuilder.Entity<UserActivity>()
            .HasOne(s => s.Activity)
            .WithMany()
            .HasForeignKey(s => s.ActivityId)
            .OnDelete(DeleteBehavior.Restrict);

        // Map UserActivity to the existing ActivitySchedules table
        modelBuilder.Entity<UserActivity>()
            .ToTable("ActivitySchedules");

        // Performance indexes
        modelBuilder.Entity<UserActivity>()
            .HasIndex(s => new { s.UserId, s.Status })
            .HasDatabaseName("IX_ActivitySchedules_UserId_Status");

        modelBuilder.Entity<UserActivity>()
            .HasIndex(s => s.PlannedDate)
            .HasDatabaseName("IX_ActivitySchedules_PlannedDate");

        modelBuilder.Entity<Activity>()
            .HasIndex(a => a.CategoryId)
            .HasDatabaseName("IX_Activities_CategoryId");

        // Seed database with activities, categories, and tags
        DatabaseSeeder.SeedData(modelBuilder);
    }
}
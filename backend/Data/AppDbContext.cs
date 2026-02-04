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
    public DbSet<ActivitySchedule> ActivitySchedules { get; set; }

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

        // ActivitySchedule - User relationship
        modelBuilder.Entity<ActivitySchedule>()
            .HasOne(s => s.User)
            .WithMany()
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // ActivitySchedule - Activity relationship
        modelBuilder.Entity<ActivitySchedule>()
            .HasOne(s => s.Activity)
            .WithMany()
            .HasForeignKey(s => s.ActivityId)
            .OnDelete(DeleteBehavior.Restrict);

        // Seed database with activities, categories, and tags
        DatabaseSeeder.SeedData(modelBuilder);
    }
}
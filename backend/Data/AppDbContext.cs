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
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostVote> PostVotes { get; set; }

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

        // Post - User relationship
        modelBuilder.Entity<Post>()
            .HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Post - Activity relationship
        modelBuilder.Entity<Post>()
            .HasOne(p => p.Activity)
            .WithMany()
            .HasForeignKey(p => p.ActivityId)
            .OnDelete(DeleteBehavior.Restrict);

        // Post indexes for performance
        modelBuilder.Entity<Post>()
            .HasIndex(p => p.ActivityId);

        modelBuilder.Entity<Post>()
            .HasIndex(p => p.UserId);

        modelBuilder.Entity<Post>()
            .HasIndex(p => p.CreatedAt);

        modelBuilder.Entity<Post>()
            .HasIndex(p => p.Score);

        // PostVote - User relationship
        modelBuilder.Entity<PostVote>()
            .HasOne(v => v.User)
            .WithMany()
            .HasForeignKey(v => v.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // PostVote - Post relationship
        modelBuilder.Entity<PostVote>()
            .HasOne(v => v.Post)
            .WithMany(p => p.Votes)
            .HasForeignKey(v => v.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        // PostVote unique constraint - one vote per user per post
        modelBuilder.Entity<PostVote>()
            .HasIndex(v => new { v.UserId, v.PostId })
            .IsUnique();

        // PostVote index for querying by post
        modelBuilder.Entity<PostVote>()
            .HasIndex(v => v.PostId);

        // Seed database with activities, categories, and tags
        DatabaseSeeder.SeedData(modelBuilder);
    }
}
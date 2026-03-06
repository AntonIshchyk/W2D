using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Backend.Models;
using System.Text.Json;

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
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostVote> PostVotes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<CommentVote> CommentVotes { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventAttendee> EventAttendees { get; set; }

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

        // Index for fast lookup of activities by category
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

        modelBuilder.Entity<Post>()
            .Property(p => p.PhotoUrls)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions?)null) ?? new List<string>(),
                new Microsoft.EntityFrameworkCore.ChangeTracking.ValueComparer<List<string>>(
                    (a, b) => a != null && b != null && a.SequenceEqual(b),
                    v => v.Aggregate(0, (h, s) => HashCode.Combine(h, s.GetHashCode())),
                    v => v.ToList()
                )
            )
            .HasColumnType("TEXT"); // use "jsonb" for Postgres

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


        // Comment - User relationship
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Comment - Post relationship
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Post)
            .WithMany(p => p.Comments)
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        // Comment - Parent/Replies self-referencing relationship
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.ParentComment)
            .WithMany(c => c.Replies)
            .HasForeignKey(c => c.ParentCommentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Comment>()
            .HasIndex(c => c.PostId);

        modelBuilder.Entity<Comment>()
            .HasIndex(c => c.UserId);

        modelBuilder.Entity<Comment>()
            .HasIndex(c => c.ParentCommentId);

        // Composite index for efficient tree queries by post and parent
        modelBuilder.Entity<Comment>()
            .HasIndex(c => new { c.PostId, c.ParentCommentId })
            .HasDatabaseName("IX_Comments_PostId_ParentCommentId");

        // Ensure Version is configured as a concurrency token
        modelBuilder.Entity<Comment>()
            .Property(c => c.Version)
            .IsConcurrencyToken();

        // Soft delete global query filter (optional, for queries)
        // modelBuilder.Entity<Comment>().HasQueryFilter(c => !c.IsDeleted);

        // CommentVote - User relationship
        modelBuilder.Entity<CommentVote>()
            .HasOne(v => v.User)
            .WithMany()
            .HasForeignKey(v => v.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // CommentVote - Comment relationship
        modelBuilder.Entity<CommentVote>()
            .HasOne(v => v.Comment)
            .WithMany(c => c.Votes)
            .HasForeignKey(v => v.CommentId)
            .OnDelete(DeleteBehavior.Cascade);

        // One vote per user per comment
        modelBuilder.Entity<CommentVote>()
            .HasIndex(v => new { v.UserId, v.CommentId })
            .IsUnique();

        modelBuilder.Entity<CommentVote>()
            .HasIndex(v => v.CommentId);

        // Event - Organizer relationship
        modelBuilder.Entity<Event>()
            .HasOne(e => e.Organizer)
            .WithMany()
            .HasForeignKey(e => e.OrganizerId)
            .OnDelete(DeleteBehavior.Cascade);

        // Event - Activity relationship (optional)
        modelBuilder.Entity<Event>()
            .HasOne(e => e.Activity)
            .WithMany()
            .HasForeignKey(e => e.ActivityId)
            .OnDelete(DeleteBehavior.SetNull);

        // Event - Tag many-to-many
        modelBuilder.Entity<Event>()
            .HasMany(e => e.Tags)
            .WithMany(t => t.Events)
            .UsingEntity(j => j.ToTable("EventTags"));

        // EventAttendee - Event relationship
        modelBuilder.Entity<EventAttendee>()
            .HasOne(a => a.Event)
            .WithMany(e => e.Attendees)
            .HasForeignKey(a => a.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        // EventAttendee - User relationship
        modelBuilder.Entity<EventAttendee>()
            .HasOne(a => a.User)
            .WithMany()
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // One RSVP per user per event
        modelBuilder.Entity<EventAttendee>()
            .HasIndex(a => new { a.EventId, a.UserId })
            .IsUnique();

        // Event performance indexes
        modelBuilder.Entity<Event>()
            .HasIndex(e => e.ScheduledAt)
            .HasDatabaseName("IX_Events_ScheduledAt");

        modelBuilder.Entity<Event>()
            .HasIndex(e => e.OrganizerId)
            .HasDatabaseName("IX_Events_OrganizerId");

        modelBuilder.Entity<Event>()
            .HasIndex(e => e.ActivityId)
            .HasDatabaseName("IX_Events_ActivityId");

        modelBuilder.Entity<Event>()
            .HasIndex(e => e.Status)
            .HasDatabaseName("IX_Events_Status");

        modelBuilder.Entity<EventAttendee>()
            .HasIndex(a => a.UserId)
            .HasDatabaseName("IX_EventAttendees_UserId");

        // Seed database with activities, categories, and tags
        DatabaseSeeder.SeedData(modelBuilder);
    }
}

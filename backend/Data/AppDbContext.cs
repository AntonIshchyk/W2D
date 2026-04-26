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
    public DbSet<Community> Communities { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostVote> PostVotes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<CommentVote> CommentVotes { get; set; }
    public DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Community unique name constraint
        modelBuilder.Entity<Community>()
            .HasIndex(c => c.Name)
            .IsUnique();

        // User unique email constraint
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        // User unique username constraint
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

        // Post - User relationship
        modelBuilder.Entity<Post>()
            .HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Post - Community relationship
        modelBuilder.Entity<Post>()
            .HasOne(p => p.Community)
            .WithMany(c => c.Posts)
            .HasForeignKey(p => p.CommunityId)
            .OnDelete(DeleteBehavior.Restrict);

        // Post indexes for performance
        modelBuilder.Entity<Post>()
            .HasIndex(p => p.CommunityId);

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

        modelBuilder.Entity<Event>()
            .Property(e => e.PhotoUrls)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions?)null) ?? new List<string>(),
                new Microsoft.EntityFrameworkCore.ChangeTracking.ValueComparer<List<string>>(
                    (a, b) => a != null && b != null && a.SequenceEqual(b),
                    v => v.Aggregate(0, (h, s) => HashCode.Combine(h, s.GetHashCode())),
                    v => v.ToList()
                )
            )
            .HasColumnType("TEXT");

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

        // Soft delete global query filter
        modelBuilder.Entity<Comment>().HasQueryFilter(c => !c.IsDeleted);

        // CommentVote - User relationship
        modelBuilder.Entity<CommentVote>()
            .HasOne(v => v.User)
            .WithMany()
            .HasForeignKey(v => v.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // CommentVote - Comment relationship (optional to handle soft-deleted comments)
        modelBuilder.Entity<CommentVote>()
            .HasOne(v => v.Comment)
            .WithMany(c => c.Votes)
            .HasForeignKey(v => v.CommentId)
            .OnDelete(DeleteBehavior.Cascade);

        // CommentVote query filter to exclude votes for soft-deleted comments
        modelBuilder.Entity<CommentVote>()
            .HasQueryFilter(v => v.Comment == null || !v.Comment.IsDeleted);

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

        // Event - Community relationship (optional)
        modelBuilder.Entity<Event>()
            .HasOne(e => e.Community)
            .WithMany()
            .HasForeignKey(e => e.CommunityId)
            .OnDelete(DeleteBehavior.SetNull);

        // Event performance indexes
        modelBuilder.Entity<Event>()
            .HasIndex(e => e.ScheduledAt)
            .HasDatabaseName("IX_Events_ScheduledAt");

        modelBuilder.Entity<Event>()
            .HasIndex(e => e.OrganizerId)
            .HasDatabaseName("IX_Events_OrganizerId");

        modelBuilder.Entity<Event>()
            .HasIndex(e => e.CommunityId)
            .HasDatabaseName("IX_Events_CommunityId");

        // Seed database with communities, communities
        DatabaseSeeder.SeedData(modelBuilder);
    }
}

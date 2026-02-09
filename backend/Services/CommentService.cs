using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Backend.Data;
using Backend.Models;
using Backend.Contracts.Comments;

namespace Backend.Services;

public class CommentService : ICommentService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CommentService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CommentResponse>> GetCommentsAsync(int postId, int? currentUserId = null)
    {
        List<Comment> comments = await _context.Comments
            .AsNoTracking()
            .Include(c => c.User)
            .Where(c => c.PostId == postId)
            .OrderByDescending(c => c.Score)
            .ThenByDescending(c => c.CreatedAt)
            .ToListAsync();

        Dictionary<int, int> userVotes = new();
        if (currentUserId.HasValue)
        {
            List<int> commentIds = comments.Select(c => c.Id).ToList();
            userVotes = await _context.CommentVotes
                .AsNoTracking()
                .Where(v => v.UserId == currentUserId.Value && commentIds.Contains(v.CommentId))
                .ToDictionaryAsync(v => v.CommentId, v => v.Value);
        }

        return comments.Select(c =>
        {
            CommentResponse response = _mapper.Map<CommentResponse>(c);
            response.CurrentUserVote = currentUserId.HasValue
                ? (userVotes.TryGetValue(c.Id, out int v) ? v : 0)
                : null;
            return response;
        }).ToList();
    }

    public async Task<CommentResponse?> CreateCommentAsync(int postId, CreateCommentRequest request, int userId)
    {
        bool postExists = await _context.Posts.AnyAsync(p => p.Id == postId);
        if (!postExists)
            return null;

        Comment comment = _mapper.Map<Comment>(request);
        comment.UserId = userId;
        comment.PostId = postId;

        _context.Comments.Add(comment);

        // Increment post comment count
        Post post = await _context.Posts.FindAsync(postId) ?? throw new InvalidOperationException();
        post.CommentCount++;

        await _context.SaveChangesAsync();

        // Load user for response
        await _context.Entry(comment).Reference(c => c.User).LoadAsync();

        CommentResponse response = _mapper.Map<CommentResponse>(comment);
        response.CurrentUserVote = 0;
        return response;
    }

    public async Task<bool> DeleteCommentAsync(int commentId, int userId)
    {
        Comment? comment = await _context.Comments.FindAsync(commentId);
        if (comment == null || comment.UserId != userId)
            return false;

        _context.Comments.Remove(comment);

        // Decrement post comment count
        Post? post = await _context.Posts.FindAsync(comment.PostId);
        if (post != null && post.CommentCount > 0)
            post.CommentCount--;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> VoteCommentAsync(int commentId, int userId, int value)
    {
        Comment? comment = await _context.Comments.FindAsync(commentId);
        if (comment == null)
            return false;

        CommentVote? existingVote = await _context.CommentVotes
            .FirstOrDefaultAsync(v => v.UserId == userId && v.CommentId == commentId);

        if (value == 0)
        {
            // Remove vote
            if (existingVote != null)
            {
                comment.Score -= existingVote.Value;
                _context.CommentVotes.Remove(existingVote);
            }
        }
        else if (existingVote != null)
        {
            // Update existing vote
            comment.Score += value - existingVote.Value;
            existingVote.Value = value;
            existingVote.UpdatedAt = DateTime.UtcNow;
        }
        else
        {
            // New vote
            _context.CommentVotes.Add(new CommentVote
            {
                UserId = userId,
                CommentId = commentId,
                Value = value
            });
            comment.Score += value;
        }

        await _context.SaveChangesAsync();
        return true;
    }
}

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
        var comments = await _context.Comments
            .AsNoTracking()
            .Include(c => c.User)
            .Where(c => c.PostId == postId)
            .ToListAsync();

        Dictionary<int, int> userVotes = new();
        if (currentUserId.HasValue)
        {
            userVotes = await _context.CommentVotes
                .AsNoTracking()
                .Where(v => v.UserId == currentUserId.Value && v.Comment.PostId == postId)
                .ToDictionaryAsync(v => v.CommentId, v => v.Value);
        }

        var responseDict = comments.ToDictionary(
            c => c.Id,
            c =>
            {
                var resp = _mapper.Map<CommentResponse>(c);
                resp.Content = c.IsDeleted ? "[deleted]" : c.Content;
                resp.IsDeleted = c.IsDeleted;
                resp.CurrentUserVote = currentUserId.HasValue ? (userVotes.TryGetValue(c.Id, out int v) ? v : 0) : null;
                resp.Replies = new List<CommentResponse>();
                return resp;
            });

        List<CommentResponse> roots = new();
        foreach (var c in comments)
        {
            if (c.ParentCommentId.HasValue)
            {
                responseDict[c.ParentCommentId.Value].Replies.Add(responseDict[c.Id]);
            }
            else
            {
                roots.Add(responseDict[c.Id]);
            }
        }

        void SortTree(CommentResponse node)
        {
            node.Replies = node.Replies
                .OrderByDescending(x => x.Score)
                .ThenByDescending(x => x.CreatedAt)
                .ToList();

            foreach (var child in node.Replies)
                SortTree(child);
        }

        foreach (var root in roots)
            SortTree(root);

        CommentResponse? Prune(CommentResponse node)
        {
            node.Replies = node.Replies
                .Select(Prune)
                .OfType<CommentResponse>()
                .ToList();

            if (!node.IsDeleted) return node;
            return node.Replies.Count > 0 ? node : null;
        }

        roots = roots
            .Select(Prune)
            .OfType<CommentResponse>()
            .ToList();

        return roots;
    }

    public async Task<CommentResponse?> CreateCommentAsync(int postId, CreateCommentRequest request, int userId)
    {
        Comment comment = _mapper.Map<Comment>(request);
        comment.UserId = userId;
        comment.PostId = postId;

        using var tx = await _context.Database.BeginTransactionAsync();

        var postExists = await _context.Posts.AnyAsync(p => p.Id == postId);
        if (!postExists)
        {
            return null;
        }

        if (request.ParentCommentId.HasValue)
        {
            var parent = await _context.Comments.FirstOrDefaultAsync(
                c => c.Id == request.ParentCommentId.Value && c.PostId == postId && !c.IsDeleted);
            if (parent == null)
            {
                await tx.RollbackAsync();
                return null;
            }
        }

        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();

        var updated = await _context.Posts
            .Where(p => p.Id == postId)
            .ExecuteUpdateAsync(s => s.SetProperty(p => p.CommentCount, p => p.CommentCount + 1));

        if (updated == 0)
        {
            await tx.RollbackAsync();
            return null;
        }

        await tx.CommitAsync();

        await _context.Entry(comment).Reference(c => c.User).LoadAsync();

        CommentResponse response = _mapper.Map<CommentResponse>(comment);
        response.Content = comment.IsDeleted ? "[deleted]" : comment.Content;
        response.IsDeleted = comment.IsDeleted;
        response.CurrentUserVote = 0;
        return response;
    }

    public async Task<bool> DeleteCommentAsync(int commentId, int userId)
    {
        var comment = await _context.Comments.FindAsync(commentId);
        if (comment == null || comment.UserId != userId)
            return false;

        if (comment.IsDeleted)
            return false;

        comment.IsDeleted = true;
        comment.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> VoteCommentAsync(int commentId, int userId, int value)
    {
        if (value < -1 || value > 1)
            return false;

        Comment? comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == commentId && !c.IsDeleted);
        if (comment == null)
            return false;

        CommentVote? existingVote = await _context.CommentVotes
            .FirstOrDefaultAsync(v => v.UserId == userId && v.CommentId == commentId);

        int oldValue = existingVote?.Value ?? 0;

        int delta = value - oldValue;
        if (delta == 0)
            return true;

        if (value == 0)
        {
            if (existingVote != null)
                _context.CommentVotes.Remove(existingVote);
        }
        else if (existingVote != null)
        {
            existingVote.Value = value;
            existingVote.UpdatedAt = DateTime.UtcNow;
        }
        else
        {
            _context.CommentVotes.Add(new CommentVote
            {
                UserId = userId,
                CommentId = commentId,
                Value = value
            });
        }

        comment.Score += delta;
        comment.UpdatedAt = DateTime.UtcNow;

        const int maxRetries = 3;
        for (int attempt = 0; attempt < maxRetries; attempt++)
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (attempt == maxRetries - 1)
                    throw;

                await _context.Entry(comment).ReloadAsync();
                comment.Score += delta;
                comment.UpdatedAt = DateTime.UtcNow;
            }
        }

        return false;
    }
}

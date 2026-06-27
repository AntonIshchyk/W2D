using Backend.Contracts.Common;
using Backend.Data;

namespace Backend.Services;

public static class VoteHelper
{
    public static async Task<Result<bool>> VoteAsync<TVote>(
        AppDbContext context,
        int entityId,
        int userId,
        int value,
        Func<Task<bool>> entityExists,
        Func<Task<TVote?>> getExistingVote,
        Func<TVote, int> getVoteValue,
        Action<TVote, int> setVoteValue,
        Func<TVote> createVote,
        Func<int, Task> updateScore)
        where TVote : class
    {
        if (value is not (-1 or 0 or 1))
            return Result<bool>.Invalid("Vote value must be -1, 0, or 1.");

        if (!await entityExists())
            return Result<bool>.NotFound("Entity not found.");

        using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            TVote? existingVote = await getExistingVote();
            int scoreDelta = 0;

            if (value == 0)
            {
                if (existingVote != null)
                {
                    scoreDelta = -getVoteValue(existingVote);
                    context.Set<TVote>().Remove(existingVote);
                }
            }
            else
            {
                if (existingVote != null)
                {
                    scoreDelta = value - getVoteValue(existingVote);
                    setVoteValue(existingVote, value);
                }
                else
                {
                    scoreDelta = value;
                    context.Set<TVote>().Add(createVote());
                }
            }

            await context.SaveChangesAsync();

            if (scoreDelta != 0)
                await updateScore(scoreDelta);

            await transaction.CommitAsync();
            return Result<bool>.Success(true);
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
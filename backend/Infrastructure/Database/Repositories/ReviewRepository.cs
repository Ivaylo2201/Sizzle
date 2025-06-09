using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class ReviewRepository(DatabaseContext context) : IReviewRepository
{
    public async Task<Result<Review>> Create(Review review)
    {
        var result = await context.Reviews.AddAsync(review);
        await context.SaveChangesAsync();
        return Result.Success(result.Entity);
    }

    public async Task<Result<List<Review>>> GetAllReviewsForProduct(Guid productId)
    {
        var reviews = await context.Reviews
            .Where(r => r.ProductId == productId)
            .ToListAsync();
        
        return Result.Success(reviews);
    }
}
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Generic;

namespace Core.Interfaces.Repositories;

public interface IReviewRepository : ICreatable<Review>
{
    public Task<Result<List<Review>>> GetAllReviewsForProduct(Guid productId);
}
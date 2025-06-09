using Application.CQRS.Reviews.Queries;
using Application.DTOs.Review;
using Application.Extensions;
using Core.Abstractions;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Reviews.Handlers;

public class ReadReviewsQueryHandler(IReviewRepository repository) : IRequestHandler<ReadReviewsQuery, Result<List<ReadReviewsDto>>>
{
    public async Task<Result<List<ReadReviewsDto>>> Handle(ReadReviewsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.GetAllReviewsForProduct(request.ProductId);
        var reviewDtos = result.Value.Select(review => review.ToDto()).ToList();
        return Result.Success(reviewDtos);
    }
}
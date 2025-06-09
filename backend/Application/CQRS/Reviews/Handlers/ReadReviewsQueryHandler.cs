using Application.CQRS.Reviews.Queries;
using Application.DTOs.Review;
using Application.Extensions;
using Core.Abstractions;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Reviews.Handlers;

public class ReadReviewsQueryHandler(IReviewRepository reviewRepository, IProductRepository productRepository) : 
    IRequestHandler<ReadReviewsQuery, Result<List<GetReviewDto>?>>
{
    public async Task<Result<List<GetReviewDto>?>> Handle(ReadReviewsQuery request, CancellationToken cancellationToken)
    {
        var productResult = await productRepository.GetOne(request.ProductId);
        
        if (!productResult.IsSuccess)
            return Result.Failure<List<GetReviewDto>?>(productResult.Error);
        
        var result = await reviewRepository.GetAllReviewsForProduct(request.ProductId);
        var reviewDtos = result.Value.Select(review => review.ToDto()).ToList();
        return Result.Success<List<GetReviewDto>?>(reviewDtos);
    }
}
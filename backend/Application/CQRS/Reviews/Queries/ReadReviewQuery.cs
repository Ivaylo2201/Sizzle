using Application.DTOs.Review;
using Core.Abstractions;
using MediatR;

namespace Application.CQRS.Reviews.Queries;

public record ReadReviewsQuery(Guid ProductId) : IRequest<Result<List<ReadReviewsDto>>>;
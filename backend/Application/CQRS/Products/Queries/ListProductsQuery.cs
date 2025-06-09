using Application.DTOs.Product;
using Core.Abstractions;
using MediatR;

namespace Application.CQRS.Products.Queries;

public record ListProductsQuery : IRequest<Result<List<GetProductShortDto>>>;
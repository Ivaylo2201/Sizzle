using Application.DTOs.Product;
using Core.Abstractions;
using MediatR;

namespace Application.CQRS.Products.Queries;

public record ListProductsQuery(string Category) : IRequest<Result<List<GetProductShortDto>>>;
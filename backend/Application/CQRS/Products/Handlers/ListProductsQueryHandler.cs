using Application.CQRS.Products.Queries;
using Application.DTOs.Product;
using Application.Extensions;
using Core.Abstractions;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Products.Handlers;

public class ListProductsQueryHandler(IProductRepository repository) : IRequestHandler<ListProductsQuery, Result<List<ReadProductShortDto>>>
{
    public async Task<Result<List<ReadProductShortDto>>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.GetAll();
        var productDtos = result.Value.Select(product => product.ToShortDto()).ToList();
        return Result.Success(productDtos);
    }
}
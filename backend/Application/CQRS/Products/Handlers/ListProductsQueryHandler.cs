using Application.CQRS.Products.Queries;
using Application.DTOs.Product;
using Application.Extensions;
using Core.Abstractions;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Products.Handlers;

public class ListProductsQueryHandler(IProductRepository productRepository) : 
    IRequestHandler<ListProductsQuery, Result<List<GetProductShortDto>>>
{
    public async Task<Result<List<GetProductShortDto>>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
    {
        var result = await productRepository.GetAll();
        var productDtos = result.Value.Select(product => product.ToShortDto()).ToList();
        return Result.Success(productDtos);
    }
}
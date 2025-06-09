using Application.CQRS.Products.Queries;
using Application.DTOs.Product;
using Application.Extensions;
using Core.Abstractions;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Products.Handlers;

public class GetProductQueryHandler(IProductRepository productRepository) : 
    IRequestHandler<GetProductQuery, Result<ReadProductLongDto?>>
{
    public async Task<Result<ReadProductLongDto?>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var result = await productRepository.GetOne(request.ProductId);

        if (!result.IsSuccess)
            return Result.Failure<ReadProductLongDto?>(result.Error);

        var dto = result.Value!.ToLongDto();
        return Result.Success<ReadProductLongDto?>(dto);
    }
}
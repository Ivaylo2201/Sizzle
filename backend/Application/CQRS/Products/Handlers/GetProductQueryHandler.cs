using Application.CQRS.Products.Queries;
using Application.DTOs.Product;
using Application.Extensions;
using Core.Abstractions;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Products.Handlers;

public class GetProductQueryHandler(IProductRepository repository) : IRequestHandler<GetProductQuery, Result<ReadProductLongDto>>
{
    public async Task<Result<ReadProductLongDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.GetOne(request.ProductId);

        if (!result.IsSuccess)
            return Result.Failure<ReadProductLongDto>(result.Error);

        var dto = result.Value!.ToLongDto();
        return Result.Success(dto);
    }
}
using Application.CQRS.Cities.Queries;
using Core.Abstractions;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Cities.Handlers;

public class ListCitiesQueryHandler(ICityRepository cityRepository) : IRequestHandler<ListCitiesQuery, Result<List<Core.Entities.City>>>
{
    public async Task<Result<List<Core.Entities.City>>> Handle(ListCitiesQuery request, CancellationToken cancellationToken)
    {
        var categoriesResult = await cityRepository.GetAllAsync();
        return Result.Success(categoriesResult.Value);
    }
}
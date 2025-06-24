using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Generic;

namespace Core.Interfaces.Repositories;

public interface ICityRepository : IMultipleReadable<City>
{
    Task<Result<City>> GetOneByNameAsync(string cityName);
}
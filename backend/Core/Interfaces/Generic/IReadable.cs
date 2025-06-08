using Core.Abstractions;

namespace Core.Interfaces.Generic;

public interface IReadable<TEntity, in TId>
{
    Task<Result<TEntity>> GetOne(TId id);
}
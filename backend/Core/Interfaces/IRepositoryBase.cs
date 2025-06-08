using Core.Abstractions;
using Core.Entities;

namespace Core.Interfaces;

public interface IRepositoryBase<TEntity, in TId> where TEntity : class
{
    Task<Result<TEntity>> Create(TEntity item);
    Task<Result<List<TEntity>>> GetAll();
    Task<Result<TEntity>> GetOne(TId id);
    Task<Result> Update(TEntity item);
    Task<Result> Delete(TId id);
}
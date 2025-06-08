using Core.Abstractions;

namespace Core.Interfaces.Generic;

public interface ICreatable<T>
{
    Task<Result<T>> Create(T item);
}
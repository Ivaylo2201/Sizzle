using Core.Abstractions;

namespace Core.Interfaces.Generic;

public interface IUpdatable<in T>
{
    Task<Result> Update(T item);
}
namespace Core.Abstractions;

public class Result
{
    public bool IsSuccess { get; }
    public string? Error { get; protected init; }

    protected Result(bool isSuccess, string? error)
    {
        if ((isSuccess && error != null) || (!isSuccess && error == null))
            throw new InvalidOperationException("Invalid result state.");
        
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, null);
    public static Result Failure(string? error) => new(false, error ?? "Operation failed.");
}

public class Result<T> : Result
{
    public T Value { get; private init; }

    private Result(bool isSuccess, string? error, T value) : base(isSuccess, error)
    {
        Value = value;
    }

    public static Result<T> Success(T value) => new(true, null, value);
    public new static Result<T> Failure(string? error) => new(false, error ?? "Operation failed.", default!);
}

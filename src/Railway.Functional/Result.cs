namespace Railway.Functional;

public class Result
{
    public bool IsSuccess { get; }
    public string Error { get; }

    protected Result(bool isSuccess, string error)
    {
        if (isSuccess && !string.IsNullOrWhiteSpace(error))
            throw new InvalidOperationException();
        
        if(!isSuccess && string.IsNullOrWhiteSpace(error)) 
            throw new InvalidOperationException();

        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Ok() => new (true, string.Empty);
    public static Result Fail(string message) => new (false, message);
}

public sealed class Result<T> : Result
{
    public T? Value { get; }

    private Result(T? value, bool isSuccess, string error) : base(isSuccess, error)
    {
        Value = value;
    }
    
    public static Result<T> Ok(T value) => new (value, true, string.Empty);
    public new static Result<T> Fail(string message) => new (default, false, message);
}
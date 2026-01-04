namespace Railway.Functional;

public static class ResultExtensions
{
    public static Result OnSuccess(this Result result, Action action)
    {
        if (!result.IsSuccess)
            return Result.Fail(result.Error);

        action();
        return result;
    }

    public static Result<T> OnSuccess<T>(this Result<T> result, Func<T, T> func)
    {
        if (!result.IsSuccess)
            return Result<T>.Fail(result.Error);

        var newValue = func(result.Value!);
        
        return Result<T>.Ok(newValue);
    }
}
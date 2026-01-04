using System;

namespace Railway.Functional;

public static class ResultExtensions
{
    public static Result OnSuccess(this Result result, Action action)
    {
        if (!result.IsSuccess)
            return result;

        action();
        return result;
    }

    public static Result<T> OnSuccess<T>(this Result<T> result, Action action)
    {
        if (!result.IsSuccess)
            return result;

        action();
        return result;
    }

    public static Result<T> OnSuccess<T>(this Result<T> result, Action<T> action)
    {
        if (!result.IsSuccess)
            return result;

        action(result.Value!);
        
        return result;
    }

    public static Result OnFail(this Result result, Action<string> action)
    {
        if (result.IsSuccess)
            return result;

        action(result.Error);

        return result;
    }

    public static Result<T> OnFail<T>(this Result<T> result, Action<string> action)
    {
        if (result.IsSuccess)
            return result;

        action(result.Error);

        return result;
    }
}
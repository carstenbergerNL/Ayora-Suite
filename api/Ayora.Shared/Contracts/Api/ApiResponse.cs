namespace Ayora.Shared.Contracts.Api;

public sealed record ApiResponse<T>(
    bool Success,
    T? Data,
    ApiError? Error
)
{
    public static ApiResponse<T> Ok(T data) => new(true, data, null);
    public static ApiResponse<T> Fail(string code, string message, IReadOnlyDictionary<string, string[]>? details = null) =>
        new(false, default, new ApiError(code, message, details));
}


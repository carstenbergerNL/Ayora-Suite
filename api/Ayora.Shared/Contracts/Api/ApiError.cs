namespace Ayora.Shared.Contracts.Api;

public sealed record ApiError(
    string Code,
    string Message,
    IReadOnlyDictionary<string, string[]>? Details = null
);


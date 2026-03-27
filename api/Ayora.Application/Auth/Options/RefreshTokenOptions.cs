namespace Ayora.Application.Auth.Options;

public sealed class RefreshTokenOptions
{
    public const string SectionName = "RefreshTokens";

    public int DaysToLive { get; init; } = 30;
}


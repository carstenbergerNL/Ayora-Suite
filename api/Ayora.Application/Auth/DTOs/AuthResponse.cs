namespace Ayora.Application.Auth.DTOs;

public sealed record AuthResponse(
    Guid UserId,
    string Email,
    IReadOnlyList<string> Roles,
    string AccessToken,
    DateTimeOffset AccessTokenExpiresAt,
    string RefreshToken,
    DateTimeOffset RefreshTokenExpiresAt
);


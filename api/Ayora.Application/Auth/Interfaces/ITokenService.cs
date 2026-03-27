namespace Ayora.Application.Auth.Interfaces;

public interface ITokenService
{
    (string AccessToken, DateTimeOffset ExpiresAt) CreateAccessToken(Guid userId, string email, IReadOnlyList<string> roles);
    (string ResetToken, DateTimeOffset ExpiresAt) CreatePasswordResetToken(Guid userId, string email);
    bool TryValidatePasswordResetToken(string token, out Guid userId, out string email);
}


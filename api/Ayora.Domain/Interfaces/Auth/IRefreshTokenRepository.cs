using Ayora.Domain.Entities.Auth;

namespace Ayora.Domain.Interfaces.Auth;

public interface IRefreshTokenRepository
{
    Task<RefreshToken?> GetByTokenAsync(string token, CancellationToken ct);
    Task CreateAsync(RefreshToken refreshToken, CancellationToken ct);
    Task RevokeAsync(Guid refreshTokenId, CancellationToken ct);
    Task RevokeAllForUserAsync(Guid userId, CancellationToken ct);
}


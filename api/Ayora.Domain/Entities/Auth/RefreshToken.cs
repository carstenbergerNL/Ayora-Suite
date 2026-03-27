namespace Ayora.Domain.Entities.Auth;

public sealed class RefreshToken
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public required string Token { get; set; }
    public DateTimeOffset ExpiryDate { get; set; }
    public bool IsRevoked { get; set; }
    public DateTimeOffset CreatedAt { get; init; }
}


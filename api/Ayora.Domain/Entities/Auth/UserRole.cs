namespace Ayora.Domain.Entities.Auth;

public sealed class UserRole
{
    public Guid UserId { get; init; }
    public Guid RoleId { get; init; }
}


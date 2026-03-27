namespace Ayora.Domain.Entities.Auth;

public sealed class Role
{
    public Guid Id { get; init; }
    public required string Name { get; set; }
}


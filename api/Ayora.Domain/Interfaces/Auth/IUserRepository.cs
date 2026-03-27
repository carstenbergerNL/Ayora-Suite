using Ayora.Domain.Entities.Auth;

namespace Ayora.Domain.Interfaces.Auth;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<User?> GetByEmailAsync(string email, CancellationToken ct);
    Task<bool> EmailExistsAsync(string email, CancellationToken ct);
    Task CreateAsync(User user, CancellationToken ct);
    Task UpdatePasswordHashAsync(Guid userId, string passwordHash, CancellationToken ct);
}


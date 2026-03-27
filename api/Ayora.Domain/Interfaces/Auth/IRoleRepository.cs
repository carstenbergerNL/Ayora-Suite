using Ayora.Domain.Entities.Auth;

namespace Ayora.Domain.Interfaces.Auth;

public interface IRoleRepository
{
    Task<Role?> GetByNameAsync(string name, CancellationToken ct);
    Task<IReadOnlyList<Role>> GetRolesForUserAsync(Guid userId, CancellationToken ct);
    Task AssignRoleAsync(Guid userId, Guid roleId, CancellationToken ct);
}


using System.Data;

namespace Ayora.Infrastructure.Data.Abstractions;

public interface IDbConnectionFactory
{
    Task<IDbConnection> OpenConnectionAsync(CancellationToken ct);
}


using System.Data;
using Ayora.Infrastructure.Data.Abstractions;

namespace Ayora.Infrastructure.Data.SqlServer;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly IDbConnectionFactory _connectionFactory;
    private IDbConnection? _connection;
    private IDbTransaction? _transaction;

    public UnitOfWork(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public IDbConnection Connection => _connection ?? throw new InvalidOperationException("UnitOfWork not started.");
    public IDbTransaction? Transaction => _transaction;

    public async Task BeginAsync(CancellationToken ct)
    {
        if (_connection is not null)
        {
            return;
        }

        _connection = await _connectionFactory.OpenConnectionAsync(ct);
        _transaction = _connection.BeginTransaction();
    }

    public Task CommitAsync(CancellationToken ct)
    {
        if (_transaction is null)
        {
            return Task.CompletedTask;
        }

        _transaction.Commit();
        _transaction.Dispose();
        _transaction = null;
        return Task.CompletedTask;
    }

    public Task RollbackAsync(CancellationToken ct)
    {
        if (_transaction is null)
        {
            return Task.CompletedTask;
        }

        _transaction.Rollback();
        _transaction.Dispose();
        _transaction = null;
        return Task.CompletedTask;
    }

    public async ValueTask DisposeAsync()
    {
        if (_transaction is not null)
        {
            _transaction.Dispose();
            _transaction = null;
        }

        if (_connection is not null)
        {
            if (_connection is IDisposable disposable)
            {
                disposable.Dispose();
            }

            _connection = null;
        }

        await Task.CompletedTask;
    }
}


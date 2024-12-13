using System.Transactions;
using ContactList.Dal.Repositories.Interfaces;
using ContactList.Dal.Settings;
using Npgsql;

namespace ContactList.Dal.Repositories;

public abstract class PostgresRepository : IPostgresRepository
{
    protected const int DefaultTimeoutInSeconds = 5;
    private readonly DalOptions _dalSettings;

    protected PostgresRepository(DalOptions dalSettings)
    {
        _dalSettings = dalSettings;
    }

    protected async Task<NpgsqlConnection> GetConnection()
    {
        if (Transaction.Current is not null &&
            Transaction.Current.TransactionInformation.Status is TransactionStatus.Aborted)
            throw new TransactionAbortedException("Transaction was aborted (probably by user cancellation request)");

        var connection = new NpgsqlConnection(_dalSettings.PostgresConnectionString);
        await connection.OpenAsync();

        // Due to in-process migrations
        connection.ReloadTypes();

        return connection;
    }
}
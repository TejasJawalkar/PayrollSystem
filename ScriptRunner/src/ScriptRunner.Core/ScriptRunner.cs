using System.Data.Common;
using System.Text;
using Microsoft.Extensions.Logging;
using ScriptRunner.Core.Models;
using ScriptRunner.Core.Persistence;
namespace ScriptRunner.Core;

public class ScriptExecutionResult
{
    public bool Success { get; init; }
    public string Output { get; init; } = string.Empty;
    public Exception? Error { get; init; }
}

public class ScriptRunner
{
    private readonly IDictionary<string, IProviderAdapter> _adapters;
    private readonly ILogger<ScriptRunner> _logger;

    public ScriptRunner(IEnumerable<IProviderAdapter> adapters, ILogger<ScriptRunner> logger)
    {
        _adapters = adapters.ToDictionary(a => a.ProviderName, StringComparer.OrdinalIgnoreCase);
        _logger = logger;
    }

    public async Task<ScriptExecutionResult> RunAsync(string scriptText, ConnectionProfile profile, CancellationToken ct)
    {
        if (!_adapters.TryGetValue(profile.Provider, out var adapter))
            throw new InvalidOperationException($"No adapter for provider {profile.Provider}");

        var cs = ProfileStore.UnprotectConnectionString(profile.EncryptedConnectionString);

        await using var conn = adapter.CreateConnection(cs);
        await conn.OpenAsync(ct);

        var batches = adapter.SplitIntoBatches(scriptText).ToList();
        var output = new StringBuilder();

        DbTransaction? tx = null;
        try
        {
            if (adapter.SupportsTransactions)
            {
                tx = await conn.BeginTransactionAsync(ct);
            }

            foreach (var batch in batches)
            {
                ct.ThrowIfCancellationRequested();
                await using var cmd = conn.CreateCommand();
                cmd.CommandText = batch;
                cmd.Transaction = tx;
                var isSelect = batch.TrimStart().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase);
                if (isSelect)
                {
                    await using var reader = await cmd.ExecuteReaderAsync(ct);
                    int rows = 0;
                    while (await reader.ReadAsync(ct)) rows++;
                    output.AppendLine($"Query returned {rows} rows");
                }
                else
                {
                    var affected = await cmd.ExecuteNonQueryAsync(ct);
                    output.AppendLine($"Affected: {affected}");
                }
            }

            if (tx != null)
                await tx.CommitAsync(ct);

            return new ScriptExecutionResult { Success = true, Output = output.ToString() };
        }
        catch (Exception ex)
        {
            if (tx != null)
            {
                try { await tx.RollbackAsync(CancellationToken.None); } catch { }
            }
            _logger.LogError(ex, "Script execution failed");
            return new ScriptExecutionResult { Success = false, Error = ex, Output = output.ToString() };
        }
        finally
        {
            await conn.CloseAsync();
        }
    }
}

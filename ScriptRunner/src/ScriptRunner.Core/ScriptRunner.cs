using System.Data.Common;
using System.Text;
using ScriptRunner.Core.DTOS;
namespace ScriptRunner.Core;



public class ScriptRunner
{
    private readonly IDictionary<string, IProviderAdapter> _adapters;


    public ScriptRunner(IEnumerable<IProviderAdapter> adapters)
    {
        _adapters = adapters.ToDictionary(a => a.ProviderName, StringComparer.OrdinalIgnoreCase);

    }

    public async Task<ScriptExecutionResult> RunAsync(ScriptRunnerInputs scriptRunInput)
    {
        if (!_adapters.TryGetValue(scriptRunInput.profile.Provider, out var adapter))
            throw new InvalidOperationException($"No adapter for provider {scriptRunInput.profile.Provider}");

        await using var conn = adapter.CreateConnection(scriptRunInput.profile.EncryptedConnectionString);
        await conn.OpenAsync(scriptRunInput.ct);

        var batches = adapter.SplitIntoBatches(scriptRunInput.scriptText).ToList();
        var output = new StringBuilder();

        DbTransaction? tx = null;
        try
        {
            if (adapter.SupportsTransactions)
            {
                tx = await conn.BeginTransactionAsync(scriptRunInput.ct);
            }

            foreach (var batch in batches)
            {
                scriptRunInput.ct.ThrowIfCancellationRequested();
                await using var cmd = conn.CreateCommand();
                cmd.CommandText = batch;
                cmd.Transaction = tx;
                var isSelect = batch.TrimStart().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase);
                if (isSelect)
                {
                    await using var reader = await cmd.ExecuteReaderAsync(scriptRunInput.ct);
                    int rows = 0;
                    while (await reader.ReadAsync(scriptRunInput.ct)) rows++;
                    output.AppendLine($"Query returned {rows} rows");
                }
                else
                {
                    var affected = await cmd.ExecuteNonQueryAsync(scriptRunInput.ct);
                    output.AppendLine($"Affected: {affected}");
                }
            }

            if (tx != null)
                await tx.CommitAsync(scriptRunInput.ct);

            return new ScriptExecutionResult { Success = true, Output = output.ToString() };
        }
        catch (Exception ex)
        {
            if (tx != null)
            {
                try { await tx.RollbackAsync(CancellationToken.None); } catch { }
            }
            return new ScriptExecutionResult { Success = false, Error = ex, Output = output.ToString() };
        }
        finally
        {
            await conn.CloseAsync();
        }
    }
}

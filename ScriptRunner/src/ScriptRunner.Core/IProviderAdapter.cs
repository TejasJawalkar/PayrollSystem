using System.Data.Common;

namespace ScriptRunner.Core;

public interface IProviderAdapter
{
    string ProviderName { get; }
    DbConnection CreateConnection(string connectionString);
    IEnumerable<string> SplitIntoBatches(string scriptText);
    bool SupportsTransactions { get; }
}

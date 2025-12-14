using System.Data.Common;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ScriptRunner.Core;

public class SqlServerAdapter : IProviderAdapter
{
    public string ProviderName => "SqlServer";
    public bool SupportsTransactions => true;

    public DbConnection CreateConnection(string connectionString)
    {
        return new SqlConnection(connectionString);
    }

    public IEnumerable<string> SplitIntoBatches(string scriptText)
    {
        if (string.IsNullOrWhiteSpace(scriptText)) yield break;
        var regex = new Regex(@"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
        var parts = regex.Split(scriptText);
        foreach (var p in parts)
        {
            if (!string.IsNullOrWhiteSpace(p))
                yield return p.Trim();
        }
    }
}

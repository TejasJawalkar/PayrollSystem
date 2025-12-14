using System.Data.Common;
using Oracle.ManagedDataAccess.Client;
using System.Text;
using System.Text.RegularExpressions;

namespace ScriptRunner.Core
{
    public class OracleAdapter : IProviderAdapter
    {
        public string ProviderName => "Oracle";
        public bool SupportsTransactions => true;

        public DbConnection CreateConnection(string connectionString)
        {
            return new OracleConnection(connectionString);
        }

        public IEnumerable<string> SplitIntoBatches(string scriptText)
        {
            if (string.IsNullOrWhiteSpace(scriptText)) yield break;

            var plsqlBlockRegex = new Regex(
                @"(?is)(CREATE\s+OR\s+REPLACE\s+(PROCEDURE|FUNCTION|TRIGGER|PACKAGE)\b.*?END\s*;|BEGIN\b.*?END\s*;)",
                RegexOptions.Singleline | RegexOptions.IgnoreCase);

            var matches = plsqlBlockRegex.Matches(scriptText);
            var consumedRegions = new List<(int start, int length)>();
            foreach (Match m in matches)
            {
                consumedRegions.Add((m.Index, m.Length));
                yield return m.Value.Trim();
            }

            var leftovers = new StringBuilder();
            int cursor = 0;
            foreach (var seg in consumedRegions.OrderBy(s => s.start))
            {
                if (seg.start > cursor)
                {
                    leftovers.Append(scriptText.Substring(cursor, seg.start - cursor));
                    leftovers.Append("\n");
                }
                cursor = seg.start + seg.length;
            }

            if (cursor < scriptText.Length)
                leftovers.Append(scriptText.Substring(cursor));

            var other = leftovers.ToString();
            if (!string.IsNullOrWhiteSpace(other))
            {
                foreach (var stmt in SplitOnSemicolonsRespectingStringsAndComments(other))
                {
                    if (!string.IsNullOrWhiteSpace(stmt))
                        yield return stmt.Trim();
                }
            }
        }

        private IEnumerable<string> SplitOnSemicolonsRespectingStringsAndComments(string sql)
        {
            if (string.IsNullOrEmpty(sql)) yield break;
            var sb = new StringBuilder();
            bool inSingleQuote = false;
            bool inDoubleQuote = false;
            bool inLineComment = false;
            bool inBlockComment = false;

            for (int i = 0; i < sql.Length; i++)
            {
                char c = sql[i];
                char next = i + 1 < sql.Length ? sql[i + 1] : '\0';

                if (!inSingleQuote && !inDoubleQuote)
                {
                    if (!inBlockComment && c == '-' && next == '-')
                    {
                        inLineComment = true;
                        sb.Append(c);
                        continue;
                    }
                    if (!inLineComment && !inBlockComment && c == '/' && next == '*')
                    {
                        inBlockComment = true;
                        sb.Append(c);
                        continue;
                    }
                    if (inBlockComment && c == '*' && next == '/')
                    {
                        inBlockComment = false;
                        sb.Append(c);
                        continue;
                    }
                }

                if (inLineComment)
                {
                    sb.Append(c);
                    if (c == '\n') inLineComment = false;
                    continue;
                }

                if (inBlockComment)
                {
                    sb.Append(c);
                    continue;
                }

                if (c == '\'' && !inDoubleQuote)
                {
                    inSingleQuote = !inSingleQuote;
                    sb.Append(c);
                    continue;
                }

                if (c == '"' && !inSingleQuote)
                {
                    inDoubleQuote = !inDoubleQuote;
                    sb.Append(c);
                    continue;
                }

                if (c == ';' && !inSingleQuote && !inDoubleQuote && !inLineComment && !inBlockComment)
                {
                    yield return sb.ToString();
                    sb.Clear();
                    continue;
                }

                sb.Append(c);
            }

            var remaining = sb.ToString();
            if (!string.IsNullOrWhiteSpace(remaining))
                yield return remaining;
        }
    }
}

using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace PayrollSystem.Data.Common
{
    public class DapperDbContext : DbContext
    {
        private readonly string _ConnectionString;
        public DapperDbContext(IConfiguration configuration)
        {
            _ConnectionString = configuration.GetConnectionString("ConnectionLink");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_ConnectionString);

    }
}

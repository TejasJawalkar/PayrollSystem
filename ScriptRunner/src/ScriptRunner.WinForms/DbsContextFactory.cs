using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ScriptRunner.Data;

namespace ScriptRunner.WinForms
{
    public class DbsContextFactory : IDesignTimeDbContextFactory<ContextDB>
    {
        public ContextDB CreateDbContext(string[] args)
        {

            var options = new DbContextOptionsBuilder<ContextDB>()
                .UseSqlServer(
                    "Data Source=TEJAS_JAWALKAR;Initial Catalog=AllScripts;Integrated Security=True;Encrypt=True;Trust Server Certificate=True",
                    b => b.MigrationsAssembly("ScriptRunner.Data"))
            .Options;

            return new ContextDB(options);
        }

    }
}

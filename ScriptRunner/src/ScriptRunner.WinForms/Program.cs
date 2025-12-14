using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScriptRunner.Core;
using ScriptRunner.Core.Persistence;
using ScriptRunner.Data;

namespace ScriptRunner.WinForms;

internal static class Program
{
    public static IServiceProvider Services { get; private set; } = null!;

    [STAThread]
    static void Main()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        Services = services.BuildServiceProvider();

        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        Application.Run(Services.GetRequiredService<MainForm>());
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging();

        // ScriptRunner services
        services.AddSingleton<IProviderAdapter, SqlServerAdapter>();
        services.AddSingleton<IProviderAdapter, OracleAdapter>();
        services.AddSingleton<ScriptRunner.Core.ScriptRunner>();

        var profilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "ScriptRunner",
            "profiles.json");

        services.AddSingleton(new ProfileStore(profilePath));

        string connectionString = "Data Source=TEJAS_JAWALKAR;Initial Catalog=AllScripts;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        services.AddDbContext<ContextDB>(options =>
            options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ScriptRunner.Data")));

        services.AddTransient<MainForm>();
        services.AddTransient<ProfileEditorForm>();
    }
}

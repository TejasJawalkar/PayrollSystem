using System.Text.Json;
using ScriptRunner.Core.Models;
using ScriptRunner.Core.Crypto;

namespace ScriptRunner.Core.Persistence;

public class ProfileStore
{
    private readonly string _path;

    public ProfileStore(string path)
    {
        _path = path;
        Directory.CreateDirectory(Path.GetDirectoryName(_path)!);
    }

    public IEnumerable<ConnectionProfile> LoadAll()
    {
        if (!File.Exists(_path)) return Enumerable.Empty<ConnectionProfile>();
        var raw = File.ReadAllText(_path);
        return JsonSerializer.Deserialize<List<ConnectionProfile>>(raw) ?? Enumerable.Empty<ConnectionProfile>();
    }

    public void SaveAll(IEnumerable<ConnectionProfile> profiles)
    {
        var raw = JsonSerializer.Serialize(profiles, new JsonSerializerOptions{WriteIndented = true});
        File.WriteAllText(_path, raw);
    }

    public static string ProtectConnectionString(string cs) => ProtectionService.Protect(cs);
    public static string UnprotectConnectionString(string encrypted) => ProtectionService.Unprotect(encrypted);
}

using System.ComponentModel.DataAnnotations;

namespace ScriptRunner.Core.Models;

public class ConnectionProfile
{
    [Key]
    public Int64 ProfileId { get; set; }
    [Required]
    public string ConnectionName { get; set; }
    [Required]
    public string Provider { get; set; }
    [Required]
    public string EncryptedConnectionString { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace ScriptRunner.Core.Models
{
    public class ExecutedScripts
    {
        [Key]
        public Int64 ScriptId { get; set; }
        [Required]
        public string ScriptText { get; set; }
        [Required]
        public DateTime ExecutedOn { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollSystem.Entity.Models.Employee
{
    public class EmployeeManagers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ManagerId { get; set; }
        [Required]
        public Int64 EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public ICollection<ReportingManagers> Reportings { get; set; }

    }
}

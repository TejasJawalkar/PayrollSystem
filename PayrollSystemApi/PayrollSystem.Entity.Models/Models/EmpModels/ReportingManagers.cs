using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollSystem.Entity.Models.Employee
{
    public class ReportingManagers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ReportingManagerId { get; set; }

        [Required]
        public long EmployeeId { get; set; }

        [Required]
        public long ManagerId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        [ForeignKey("ManagerId")]
        public EmployeeManagers Manager { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollSystem.Entity.Models.Employee
{
    public class EmployeeSecurity
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 UserSecurityId { get; set; }
        [Required]
        public Int64 EmployeeId { get; set; }
        [Required]
        public Byte[] UserPassword { get; set; }
        #endregion

        #region Relation References
        public Employee Employee { get; set; }
        #endregion
    }
}

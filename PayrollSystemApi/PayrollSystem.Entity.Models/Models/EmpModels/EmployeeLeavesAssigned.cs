#region Namespace
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
#endregion

namespace PayrollSystem.Entity.Models.Employee
{
    public class EmployeeLeavesAssigned
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 EmployeeLeavesAssignedId { get; set; }
        [AllowNull]
        public Double PaidOff { get; set; }
        [AllowNull]
        public Double CompensentryOff { get; set; } = 0;
        [AllowNull]
        public Double MaternityOff { get; set; } = 0;
        [AllowNull]
        public Double PaternityOff { get; set; } = 0;
        [AllowNull]
        public Int32 ForYear { get; set; }
        #endregion

        #region References
        public Employee Employee { get; set; }
        #endregion
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollSystem.Entity.Models.Employee
{
    public class Department
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 DepartmentId { get; set; }
        [Required]
        [MaxLength(200)]
        public string DepartementName { get; set; }
        #endregion

        #region Relation References
        public ICollection<Employee> Employee { get; set; }
        #endregion
    }
}

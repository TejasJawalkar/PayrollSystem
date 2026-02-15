
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollSystem.Entity.Models.Employee
{
    public class Designation
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 RoleId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Role { get; set; }
        [Required]
        [MaxLength(10)]
        public Int64 Stamp { get; set; }
        #endregion

        #region Relation References
        public ICollection<Employee> Employee { get; set; }
        #endregion
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace PayrollSystem.Entity.Models.Employee
{
    public class EmployeeDetails
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 EmployeeDetails_Id { get; set; }
        public Int64 EmployeeId { get; set; }
        [Required]
        public string E_Fir_Name { get; set; }
        [AllowNull]
        public string E_Mid_Name { get; set; } = "";
        [Required]
        public string E_Last_Name { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string OrganisationEmail { get; set; }
        public string PersonalEmail { get; set; }
        [Required]
        [MaxLength(50)]
        [Phone]
        public string Mobile { get; set; }
        public string MobileNoCode { get; set; } = "";
        [Required]
        public bool IsActive { get; set; } = true;
        public bool IsPasswordChangeActive { get; set; } = true;

        [AllowNull]
        public string Pancard_No { get; set; }
        [AllowNull]
        public Int64 AadharCard_No { get; set; }

        [AllowNull]
        public string UAN_No { get; set; }
        #endregion

        #region Relation References
        public Employee Employee { get; set; }
        #endregion
    }
}

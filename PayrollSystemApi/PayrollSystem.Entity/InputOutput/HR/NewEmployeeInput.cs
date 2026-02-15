using Microsoft.AspNetCore.Mvc;

namespace PayrollSystem.Entity.InputOutput.HR
{
    public class NewEmployeeInput
    {
        [FromForm] public Int64 OrgnisationID { get; set; }
        [FromForm] public Int64 DepartmentId { get; set; }
        [FromForm] public Int64 EmployeeId { get; set; }
        [FromForm] public Int64 RoleId { get; set; }
        [FromForm] public String Employee_FirstName { get; set; }
        [FromForm] public String Employee_MiddleName { get; set; }
        [FromForm] public String Employee_LastName { get; set; }
        [FromForm] public String OrganisationEmail { get; set; }
        [FromForm] public String PersonalEmail { get; set; }
        [FromForm] public String Mobile { get; set; }
        [FromForm] public Double MobileNoCode { get; set; }
        [FromForm] public Double CTC { get; set; }
        [FromForm] public Double GrossPay { get; set; }
        [FromForm] public Double NetPay { get; set; }
        [FromForm] public Double PaternityOff { get; set; }
        [FromForm] public Int64 ForYear { get; set; }
        [FromForm] public Double CompensentryOff { get; set; }
        [FromForm] public Double MaternityOff { get; set; }
        [FromForm] public Double PaidOff { get; set; }
        [FromForm] public string Pancard_No { get; set; }
        [FromForm] public string UAN_No { get; set; }
        [FromForm] public Int64 AadharCard_No { get; set; }
    }
}

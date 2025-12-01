using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PayrollSystem.Data.Common;
using PayrollSystem.Entity.InputOutput.System;
using PayrollSystem.Entity.Models.Employee;

namespace PayrollSystem.Controllers
{
    public class SystemController : Controller
    {
        private readonly DbsContext _bsContext;
        public SystemController(DbsContext dbsContext)
        {
            _bsContext = dbsContext;
        }
        [HttpPost]
        [Route("System/AddOrganization")]
        public IActionResult AddOrganization([FromForm] OrganizationInput organizationInput)
        {
            try
            {
                var organization = new Orgnisations
                {
                    OrgnizationName = organizationInput.OrgnizationName,
                    OrgnisationAddress = organizationInput.OrgnisationAddress,
                    OrgnisationCountry = organizationInput.OrgnisationCountry,
                    OrgnisationState = organizationInput.OrgnisationState,
                    OrgnisationPincode = organizationInput.OrgnisationPincode,
                    OrgnisationStartDate = Convert.ToDateTime(organizationInput.OrgnisationStartDate),
                    OrgnisationDirectorName = organizationInput.OrgnisationDirectorName,
                    DirectorMobileNo = organizationInput.DirectorEmail,
                    DirectorEmail = organizationInput.DirectorEmail,
                    OrgnisationCeo = organizationInput.OrgnisationCeo,
                    CeoMobileNo = organizationInput.CeoMobileNo,
                    CeoEmail = organizationInput.CeoEmail,
                    OrgnisationGstNo = organizationInput.OrgnisationGstNo,
                    OrgnisationStartTime = organizationInput.OrgnisationStartTime.IsNullOrEmpty() ? "" : organizationInput.OrgnisationStartTime,
                    OrgnisationEndTime = organizationInput.OrgnisationEndTime.IsNullOrEmpty() ? "" : organizationInput.OrgnisationEndTime,
                    IsActive = true,
                    SystemRegisteredDate = DateTime.Now,
                };
                _bsContext.TblOragnizations.Add(organization);
                _bsContext.SaveChanges();
                return Ok(new { message = "Organisation Saved" });
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        [Route("System/AddRoles")]
        public IActionResult AddRoles([FromForm] String RoleName)
        {
            try
            {
                var roles = new Designation
                {
                    Role = RoleName,
                };

                _bsContext.TblRoles.Add(roles);
                _bsContext.SaveChanges();
                return Ok(new { message = "Role Added" });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        [HttpPost]
        [Route("System/AddDepartments")]
        public IActionResult AddDepartments([FromForm] String departmentNm)
        {
            try
            {
                var department = new Department
                {
                    DepartementName = departmentNm
                };
                _bsContext.TblDepartments.Add(department);
                _bsContext.SaveChanges();
                return Ok(new { message = "Department Added" });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("System/GetDepartments")]
        public IActionResult GetDepartments()
        {
            try
            {
                var departments = _bsContext.TblDepartments.ToList();
                return Ok(departments);
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }
    }
}

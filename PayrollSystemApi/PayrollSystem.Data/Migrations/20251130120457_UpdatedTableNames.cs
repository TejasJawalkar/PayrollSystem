using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayrollSystem.Data.Migrations
{
    public partial class UpdatedTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblDepartments",
                columns: table => new
                {
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartementName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblDepartments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "TblOragnizations",
                columns: table => new
                {
                    OrgnisationID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgnizationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrgnisationAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrgnisationCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrgnisationState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrgnisationPincode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrgnisationStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrgnisationDirectorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectorMobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectorEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrgnisationCeo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CeoMobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CeoEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrgnisationGstNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrgnisationStartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrgnisationEndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SystemRegisteredDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblOragnizations", x => x.OrgnisationID);
                });

            migrationBuilder.CreateTable(
                name: "TblPaymentDetails",
                columns: table => new
                {
                    PaymentID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CTC = table.Column<double>(type: "float", nullable: false),
                    GrossPay = table.Column<double>(type: "float", nullable: false),
                    NetPay = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPaymentDetails", x => x.PaymentID);
                });

            migrationBuilder.CreateTable(
                name: "TblRoles",
                columns: table => new
                {
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Stamp = table.Column<long>(type: "bigint", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRoles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "TblRoutingNavigationMain",
                columns: table => new
                {
                    MainRouteId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorizedUsers = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRoutingNavigationMain", x => x.MainRouteId);
                });

            migrationBuilder.CreateTable(
                name: "TsyExceptionLogs",
                columns: table => new
                {
                    ExceptionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ExceptionMessage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SiteName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TsyExceptionLogs", x => x.ExceptionId);
                });

            migrationBuilder.CreateTable(
                name: "TsyUserLogs",
                columns: table => new
                {
                    LogID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BrowswerUsed = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TsyUserLogs", x => x.LogID);
                });

            migrationBuilder.CreateTable(
                name: "TblEmployee",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    PaymentID = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeLeavesAssignedId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEmployee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_TblEmployee_TblDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "TblDepartments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblEmployee_TblOragnizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "TblOragnizations",
                        principalColumn: "OrgnisationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblEmployee_TblPaymentDetails_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "TblPaymentDetails",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblEmployee_TblRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "TblRoles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblRoutingNavigationChild",
                columns: table => new
                {
                    ChildRouteID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainRouteId = table.Column<long>(type: "bigint", nullable: false),
                    RouteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RouteUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRoutingNavigationChild", x => x.ChildRouteID);
                    table.ForeignKey(
                        name: "FK_TblRoutingNavigationChild_TblRoutingNavigationMain_MainRouteId",
                        column: x => x.MainRouteId,
                        principalTable: "TblRoutingNavigationMain",
                        principalColumn: "MainRouteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLeavesAssigned",
                columns: table => new
                {
                    EmployeeLeavesAssignedId = table.Column<long>(type: "bigint", nullable: false),
                    TotalLeaves = table.Column<double>(type: "float", nullable: false),
                    ForYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLeavesAssigned", x => x.EmployeeLeavesAssignedId);
                    table.ForeignKey(
                        name: "FK_EmployeeLeavesAssigned_TblEmployee_EmployeeLeavesAssignedId",
                        column: x => x.EmployeeLeavesAssignedId,
                        principalTable: "TblEmployee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSecurity",
                columns: table => new
                {
                    UserSecurityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    UserPassword = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSecurity", x => x.UserSecurityId);
                    table.ForeignKey(
                        name: "FK_EmployeeSecurity_TblEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "TblEmployee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblDailyTimeSheet",
                columns: table => new
                {
                    TimeSheetId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    LoginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoginLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogOutDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LogOutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LogoutLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalHoursWorked = table.Column<double>(type: "float", nullable: true),
                    AttendanceFlag = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblDailyTimeSheet", x => x.TimeSheetId);
                    table.ForeignKey(
                        name: "FK_TblDailyTimeSheet_TblEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "TblEmployee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblEmployeeDetails",
                columns: table => new
                {
                    EmployeeDetails_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganisationEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PersonalEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MobileNoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsPasswordChangeActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEmployeeDetails", x => x.EmployeeDetails_Id);
                    table.ForeignKey(
                        name: "FK_TblEmployeeDetails_TblEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "TblEmployee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblEmployeeLeaves",
                columns: table => new
                {
                    LeaveId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    AppliedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    ApprovedBy = table.Column<int>(type: "int", nullable: false),
                    AppliedReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RejectedReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoofDays = table.Column<double>(type: "float", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsRejected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEmployeeLeaves", x => x.LeaveId);
                    table.ForeignKey(
                        name: "FK_TblEmployeeLeaves_TblEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "TblEmployee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblManagers",
                columns: table => new
                {
                    ManagerID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblManagers", x => x.ManagerID);
                    table.ForeignKey(
                        name: "FK_TblManagers_TblEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "TblEmployee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblEmployeeManagers",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    ManagerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEmployeeManagers", x => new { x.EmployeeId, x.ManagerId });
                    table.ForeignKey(
                        name: "FK_TblEmployeeManagers_TblEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "TblEmployee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblEmployeeManagers_TblManagers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "TblManagers",
                        principalColumn: "ManagerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSecurity_EmployeeId",
                table: "EmployeeSecurity",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblDailyTimeSheet_EmployeeId",
                table: "TblDailyTimeSheet",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblEmployee_DepartmentId",
                table: "TblEmployee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TblEmployee_OrganizationId",
                table: "TblEmployee",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_TblEmployee_PaymentID",
                table: "TblEmployee",
                column: "PaymentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblEmployee_RoleId",
                table: "TblEmployee",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TblEmployeeDetails_EmployeeId",
                table: "TblEmployeeDetails",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblEmployeeLeaves_EmployeeId",
                table: "TblEmployeeLeaves",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblEmployeeManagers_ManagerId",
                table: "TblEmployeeManagers",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_TblManagers_EmployeeId",
                table: "TblManagers",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblRoutingNavigationChild_MainRouteId",
                table: "TblRoutingNavigationChild",
                column: "MainRouteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeLeavesAssigned");

            migrationBuilder.DropTable(
                name: "EmployeeSecurity");

            migrationBuilder.DropTable(
                name: "TblDailyTimeSheet");

            migrationBuilder.DropTable(
                name: "TblEmployeeDetails");

            migrationBuilder.DropTable(
                name: "TblEmployeeLeaves");

            migrationBuilder.DropTable(
                name: "TblEmployeeManagers");

            migrationBuilder.DropTable(
                name: "TblRoutingNavigationChild");

            migrationBuilder.DropTable(
                name: "TsyExceptionLogs");

            migrationBuilder.DropTable(
                name: "TsyUserLogs");

            migrationBuilder.DropTable(
                name: "TblManagers");

            migrationBuilder.DropTable(
                name: "TblRoutingNavigationMain");

            migrationBuilder.DropTable(
                name: "TblEmployee");

            migrationBuilder.DropTable(
                name: "TblDepartments");

            migrationBuilder.DropTable(
                name: "TblOragnizations");

            migrationBuilder.DropTable(
                name: "TblPaymentDetails");

            migrationBuilder.DropTable(
                name: "TblRoles");
        }
    }
}

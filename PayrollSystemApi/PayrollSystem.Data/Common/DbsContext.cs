using Microsoft.EntityFrameworkCore;
using PayrollSystem.Entity.Models.Employee;
using PayrollSystem.Entity.Models.Logging;
using PayrollSystem.Entity.Models.Models.SystemConfigurationModel;


namespace PayrollSystem.Data.Common
{
    public class DbsContext : DbContext
    {
        #region Constructor
        public DbsContext(DbContextOptions<DbsContext> options) : base(options) { }
        #endregion

        #region All DbSet
        public DbSet<Employee> TblEmployee { get; set; }
        public DbSet<PaymentData> TblPaymentDetails { get; set; }
        public DbSet<Orgnisations> TblOragnizations { get; set; }
        public DbSet<ExceptionLog> TsyExceptionLogs { get; set; }
        public DbSet<UserLogs> TsyUserLogs { get; set; }
        public DbSet<DailyTimeSheet> TblDailyTimeSheet { get; set; }
        public DbSet<UserLeave> TblEmployeeLeaves { get; set; }
        public DbSet<Department> TblDepartments { get; set; }
        public DbSet<Designation> TblRoles { get; set; }
        public DbSet<ReportingManagers> TblManagers { get; set; }
        public DbSet<EmployeeManagers> TblEmployeeManagers { get; set; }
        public DbSet<EmployeeDetails> TblEmployeeDetails { get; set; }
        public DbSet<RoutingNavigationModel> TblRoutingNavigationMain { get; set; }
        public DbSet<RoutingNavigationChildModel> TblRoutingNavigationChild { get; set; }
        public DbSet<EmployeeSecurity> TblEmployeeSecurity { get; set; }
        public DbSet<EmployeeLeavesAssigned> TblEmployeeLeavesAssigned { get; set; }

        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region One To One Relationship
            modelBuilder.Entity<Employee>()
                .HasOne(ela => ela.EmployeeLeavesAssigned)
                .WithOne(e => e.Employee)
                .HasForeignKey<Employee>(e => e.EmployeeLeavesAssignedId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(ed => ed.EmployeeDetails)
                .WithOne(e => e.Employee)
                .HasForeignKey<EmployeeDetails>(fk => fk.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(ed => ed.EmployeeSecurity)
                .WithOne(e => e.Employee)
                .HasForeignKey<EmployeeSecurity>(fk => fk.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
               .HasOne(ed => ed.PaymentData)
               .WithOne(e => e.Employee)
               .HasForeignKey<Employee>(fk => fk.PaymentID)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmployeeManagers>()
                .HasOne(e => e.Employee)
                .WithOne(e => e.EmployeeManagers)
                .HasForeignKey<Employee>(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region One To Many Relationship
            modelBuilder.Entity<Employee>()
               .HasOne(ed => ed.Department)
               .WithMany(e => e.Employee)
               .HasForeignKey(fk => fk.DepartmentId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(ed => ed.Designation)
                .WithMany(e => e.Employee)
                .HasForeignKey(fk => fk.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(o => o.Orgnisations)
                .WithMany(e => e.Employees)
                .HasForeignKey(fk => fk.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DailyTimeSheet>()
                .HasOne(e => e.Employee)
                .WithMany(edt => edt.DailyTimeSheets)
                .HasForeignKey(fk => fk.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserLeave>()
                .HasOne(e => e.Employee)
                .WithMany(ul => ul.UserLeave)
                .HasForeignKey(fk => fk.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RoutingNavigationChildModel>()
                .HasOne(e => e.RoutingNavigationModel)
                .WithMany(ul => ul.RoutingChildModels)
                .HasForeignKey(fk => fk.MainRouteId)
                .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<EmployeeManagers>()
    .HasOne(m => m.Employee)
    .WithOne(e => e.EmployeeManagers)
    .HasForeignKey<EmployeeManagers>(m => m.EmployeeId)
    .OnDelete(DeleteBehavior.Restrict);

            // Unique constraint: one employee can become manager only once
            modelBuilder.Entity<EmployeeManagers>()
                .HasIndex(m => m.EmployeeId)
                .IsUnique();

            // ReportingManagers → Employee (Many-to-One)
            modelBuilder.Entity<ReportingManagers>()
                .HasOne(r => r.Employee)
                .WithMany(e => e.ReportingManagers)
                .HasForeignKey(r => r.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // ReportingManagers → EmployeeManagers (Many-to-One)
            modelBuilder.Entity<ReportingManagers>()
                .HasOne(r => r.Manager)
                .WithMany(m => m.Reportings)
                .HasForeignKey(r => r.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Optional: prevent duplicate employee-manager pair
            modelBuilder.Entity<ReportingManagers>()
                .HasIndex(r => new { r.EmployeeId, r.ManagerId })
                .IsUnique();
            #endregion

            #region Many To Many 

            #endregion
        }
        #endregion
    }
}

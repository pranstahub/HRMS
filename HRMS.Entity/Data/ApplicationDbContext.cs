using HRMS.Entity.Models;
using HRMS.Entity.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace HRMS.Entity.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
        {
        }
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }
        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public DbSet<EmployeeLeave> EmployeeLeaves { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }
        public DbSet<EmployeeTraining> EmployeeTrainings { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Training> Trainings { get; set; }

        public DbSet<JnEmployeeProject> jnEmployeeProjects { get; set; }
        public DbSet<JnEmployeeTraining> jnEmployeeTraining { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDetail>()
                .HasOne(ed => ed.department)
                .WithMany(d => d.employeeDetails)
                .HasForeignKey(ed => ed.deptId);

            modelBuilder.Entity<EmployeeAttendance>()
                .HasOne(ea => ea.empDetail)
                .WithMany(ed => ed.attendances)
                .HasForeignKey(ea => ea.empId);

            modelBuilder.Entity<EmployeeLeave>()
                .HasOne(el => el.empDetail)
                .WithMany(ed => ed.leaves)
                .HasForeignKey(el => el.empId);


            modelBuilder.Entity<JnEmployeeProject>()
            .HasKey(jn => new { jn.empId, jn.projectID });

            modelBuilder.Entity<JnEmployeeProject>()
                .HasOne(jn => jn.employeeDetail)
                .WithMany(ed => ed.jnEmployeeProjects)
                .HasForeignKey(jn => jn.empId);

            modelBuilder.Entity<JnEmployeeProject>()
                .HasOne(jn => jn.project)
                .WithMany(p => p.jnEmployeeProjects)
                .HasForeignKey(jn => jn.projectID);


            modelBuilder.Entity<EmployeeSalary>()
                .HasOne(es => es.empDetail)
                .WithOne(ed => ed.salary)
                .HasForeignKey<EmployeeSalary>(es => es.empId);


            modelBuilder.Entity<JnEmployeeTraining>()
            .HasKey(jn => new { jn.empId, jn.trainingID });

            modelBuilder.Entity<JnEmployeeTraining>()
                .HasOne(jn => jn.employeeDetail)
                .WithMany(ed => ed.jnEmpTraining)
                .HasForeignKey(jn => jn.empId);

            modelBuilder.Entity<JnEmployeeTraining>()
                .HasOne(jn => jn.training)
                .WithMany(t => t.jnEmpTraining)
                .HasForeignKey(jn => jn.trainingID);


            modelBuilder.Entity<EmployeeLeave>()
               .HasOne(el => el.leave)
               .WithMany(l => l.empLeaves)
               .HasForeignKey(el => el.leaveId);

            modelBuilder.Entity<EmployeeDetail>()
               .HasOne(ed => ed.location)
               .WithMany(loc => loc.employees)
               .HasForeignKey(ed => ed.locationId);

            modelBuilder.Entity<News>()
               .HasOne(n => n.empDetail)
               .WithMany(ed => ed.news)
               .HasForeignKey(n => n.empId);

            modelBuilder.Entity<EmployeeDetail>()
               .HasOne<Position>(ed => ed.position)
               .WithMany(p => p.employees)
               .HasForeignKey(ed => ed.positionId);

            modelBuilder.Entity<EmployeeProject>()
               .HasOne<Project>(ep => ep.project)
               .WithMany(p => p.employeeProjects)
               .HasForeignKey(ep => ep.projectId);

            modelBuilder.Entity<EmployeeTraining>()
               .HasOne<Training>(et => et.training)
               .WithMany(t => t.employeeTraining)
               .HasForeignKey(et => et.trainingId);

            SeedUsers(modelBuilder);
            SeedRoles(modelBuilder);
            SeedUserRole(modelBuilder);
            base.OnModelCreating(modelBuilder);

        }

        private void SeedUsers(ModelBuilder modelBuilder)
        {
            ApplicationUser user = new()
            {
                Id = "hcg67b93tf374ivbgy3ufiht3yiuqbgevowq",
                UserName = "Admin",
                Email = "Admin@uis.com",
                PhoneNumber = "9995246666",
            };

            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Abc@123");
            modelBuilder.Entity<ApplicationUser>().HasData(user);
        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            IdentityRole role = new()
            {
                Id = "oifu3789rgy28r3yq967f8329f2huih2f32",
                Name = "Admin",
                NormalizedName = "ADMIN"
            };
            modelBuilder.Entity<IdentityRole>().HasData(role);
        }

        private void SeedUserRole(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "oifu3789rgy28r3yq967f8329f2huih2f32", UserId = "hcg67b93tf374ivbgy3ufiht3yiuqbgevowq" });
        }
    }
}

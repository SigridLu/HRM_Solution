using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onboarding_ApplicationCore.Entity;

namespace Onboarding_Infrastructure.Data
{
    public class OnboardingDbContext : DbContext
    {
        public OnboardingDbContext(DbContextOptions<OnboardingDbContext> option) : base(option)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeRole> EmployeeRole { get; set; }
        public DbSet<EmployeeCategory> EmployeeCategory { get; set; }
        public DbSet<EmployeeStatus> EmployeeStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(ConfigureEmployee);
            modelBuilder.Entity<EmployeeRole>(ConfigureEmployeeRole);
            modelBuilder.Entity<EmployeeCategory>(ConfigureEmployeeCategory);
            modelBuilder.Entity<EmployeeStatus>(ConfigureEmployeeStatus);
        }

        private void ConfigureEmployee(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.HasKey(e => e.Id);
            builder.HasOne(er => er.EmployeeRole).WithMany(e => e.Employees).HasForeignKey(e => e.EmployeeRoleId);
            builder.HasOne(ec => ec.EmployeeCategory).WithMany(e => e.Employees).HasForeignKey(e => e.EmployeeCategoryCode);
            builder.HasOne(es => es.EmployeeStatus).WithMany(e => e.Employees).HasForeignKey(e => e.EmployeeStatusCode);
        }

        private void ConfigureEmployeeRole(EntityTypeBuilder<EmployeeRole> builder)
        {
            builder.ToTable("EmployeeRole");
            builder.HasKey(e => e.LookupCode);
        }

        private void ConfigureEmployeeCategory(EntityTypeBuilder<EmployeeCategory> builder)
        {
            builder.ToTable("EmployeeCategory");
            builder.HasKey(e => e.LookupCode);
        }

        private void ConfigureEmployeeStatus(EntityTypeBuilder<EmployeeStatus> builder)
        {
            builder.ToTable("EmployeeStatus");
            builder.HasKey(e => e.LookupCode);
        }
    }
}


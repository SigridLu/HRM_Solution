using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Onboarding_Infrastructure.Data
{
    public class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<OnboardingDbContext>
    {
        public OnboardingDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<OnboardingDbContext> builder = new DbContextOptionsBuilder<OnboardingDbContext>();
            builder.UseSqlServer("Data Source=192.168.1.239,1433; Database=HRM_Onboarding; User Id=sa; Password=PA_Clemson$$2020; TrustServerCertificate=true;");
            return new OnboardingDbContext(builder.Options);
        }
    }
}


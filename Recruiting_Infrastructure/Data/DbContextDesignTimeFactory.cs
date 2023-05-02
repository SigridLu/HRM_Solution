using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Recruiting_Infrastructure.Data
{
    public class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<RecruitingDbContext>
    {
        public RecruitingDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<RecruitingDbContext> builder = new DbContextOptionsBuilder<RecruitingDbContext>();
            builder.UseSqlServer("Data Source=192.168.1.239,1433; Database=HRM_Recruiting; User Id=sa; Password=PA_Clemson$$2020; TrustServerCertificate=true;");
            return new RecruitingDbContext(builder.Options);
        }
    }
}


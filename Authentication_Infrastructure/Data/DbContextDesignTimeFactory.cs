using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Authentication_Infrastructure.Data
{
    public class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<AuthenticationDbContext>
    {
        public AuthenticationDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<AuthenticationDbContext> builder = new DbContextOptionsBuilder<AuthenticationDbContext>();
            builder.UseSqlServer("Data Source=192.168.1.239,1433; Database=HRM_Authentication; User Id=sa; Password=PA_Clemson$$2020; TrustServerCertificate=true;");
            return new AuthenticationDbContext(builder.Options);
        }
    }
}


using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Onboarding_ApplicationCore.Contract.Repository;
using Onboarding_ApplicationCore.Entity;
using Onboarding_Infrastructure.Data;

namespace Onboarding_Infrastructure.Repository
{
    public class EmployeeRoleRepository : BaseRepository<EmployeeRole>, IEmployeeRoleRepository
    {
        public EmployeeRoleRepository(OnboardingDbContext context) : base(context)
        {
        }

        public async Task<EmployeeRole> GetEmployeeRoleByRoleName(string RoleName)
        {
            return await _dbContext.EmployeeRole.Where(x => x.Name == RoleName.ToLower()).FirstOrDefaultAsync();
        }
    }
}


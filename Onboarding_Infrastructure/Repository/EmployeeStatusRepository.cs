using System;
using Onboarding_ApplicationCore.Contract.Repository;
using Onboarding_ApplicationCore.Entity;
using Onboarding_Infrastructure.Data;

namespace Onboarding_Infrastructure.Repository
{
    public class EmployeeStatusRepository : BaseRepository<EmployeeStatus>, IEmployeeStatusRepository
    {
        public EmployeeStatusRepository(OnboardingDbContext context) : base(context)
        {
        }
    }
}


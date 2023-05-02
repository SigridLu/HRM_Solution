using System;
using Onboarding_ApplicationCore.Contract.Repository;
using Onboarding_ApplicationCore.Entity;
using Onboarding_Infrastructure.Data;

namespace Onboarding_Infrastructure.Repository
{
    public class EmployeeCategoryRepository : BaseRepository<EmployeeCategory>, IEmployeeCategoryRepository
    {
        public EmployeeCategoryRepository(OnboardingDbContext context) : base(context)
        {
        }
    }
}


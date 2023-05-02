using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Onboarding_ApplicationCore.Contract.Repository;
using Onboarding_ApplicationCore.Entity;
using Onboarding_Infrastructure.Data;

namespace Onboarding_Infrastructure.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(OnboardingDbContext context) : base(context)
        {
        }

        public async Task<Employee> FirstOrDefaultWithIncludesAsync(Expression<Func<Employee, bool>> where,
            params Expression<Func<Employee, object>>[] includes)
        {
            var query = _dbContext.Set<Employee>().AsQueryable();

            if (includes != null)
                foreach (var navigationProperty in includes)
                    query = query.Include(navigationProperty);

            return await query.FirstOrDefaultAsync(where);
        }
    }
}

